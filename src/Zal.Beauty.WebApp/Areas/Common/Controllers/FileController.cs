using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Pls.Utils.oss;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.IManager.Commons;
using Zal.Beauty.Interface.Models.Parameters.Commons;
using Zal.Beauty.Interface.Models.Results.Commons;

namespace Zal.Beauty.WebApp.Areas.Common.Controllers
{
    /// <summary>
    /// 素材管理
    /// </summary>
    [Area("Common")]
    public class FileController : Controller
    {
        public readonly IFileManager manager;
        public readonly IHostingEnvironment hostingEnvironment;
        public FileController(IFileManager manager, IHostingEnvironment env)
        {
            this.hostingEnvironment = env;
            this.manager = manager;
        }
        /// <summary>
        /// 返回素材管理界面
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> FileIndex()
        {
            List<TagResult> tagList = await manager.GetTagAllAsync();
            return View("FileIndex", tagList);
        }
        /// <summary>
        /// 添加素材分类
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddTag(String name, int weight)
        {
            var result = await manager.AddTagAsync(name, weight);
            return Json(result);
        }

        /// <summary>
        /// 返回素材上传界面
        /// </summary>
        /// <returns></returns>
        public IActionResult FileUpload(String tagName,int tagId)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("tagId",tagId);
            map.Add("tagName", tagName);
            return View("FileUpload", map);
        }
        /// <summary>
        /// 素材上传OSS
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> UploadOSS(List<IFormFile> files, String tagId)
        {
            ReturnResult result = new ReturnResult();
            long id = long.Parse(tagId);
            foreach (var file in files)
            {
                ReturnResult check = OssOptionUtil.CheckFile(file);
                if (check.IsSuccess == false)//判断素材是否符合上传条件
                {
                    return Json(check);
                }
                else
                {
                    //获取OSSkey
                    Dictionary<String, String> map = OssOptionUtil.GetOSSKey(file, OssOptionUtil.localhost_image, hostingEnvironment.WebRootPath, check.Message);
                    int count = await manager.GetFileCountByOssKey(map["fileKey"]);
                    if (count > 0)
                    {
                        await manager.UpdateTime(map["fileKey"]);//更新上传时间
                        result.Message = "上传成功";
                        return Json(result);
                    }
                    else
                    {
                        FileParameter fileParameter = OssOptionUtil.OssUpload(map["filePath"], file, check.Message, id, map["fileKey"]);
                        await manager.AddFileAsync(fileParameter);
                        result.Message = "上传成功";
                        return Json(result);
                    }
                }

            }
            result.IsSuccess = false;
            return Json(result);
        }
        /// <summary>
        /// 获取素材分类下所有的素材
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAllFile(long tagId,int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            EntitySet<Interface.Models.Results.Commons.FileResult> files = await manager.GetAllFileAsync(tagId,page);
            foreach (var item in files.Entities)
            {
                item.Url = OssOptionUtil.GetOSSUrl(item.OssKey);
            }
            return Json(files);
        }

        /// <summary>
        /// 修改素材名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IActionResult> ModifyFileName(String id,String name)
        {
            long fileId = long.Parse(id);
            await manager.ModifyFileName(fileId, name);
            return Json("success");
        }
        /// <summary>
        /// 删除素材
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteFile(String id)
        {
            long fileId = long.Parse(id);
            await manager.DeleteFile(fileId);
            return Json("success");
        }

        /// <summary>
        /// 批量删除素材
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> LotDeleteFile(String[] fileId)
        {
            for(var i = 0; i < fileId.Length; i++)
            {
                long id = long.Parse(fileId[i]);
                await manager.DeleteFile(id);
            }
            return Json("success");
        }
    }
}
