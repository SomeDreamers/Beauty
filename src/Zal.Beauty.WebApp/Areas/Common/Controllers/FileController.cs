using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.IManager.Commons;
using Zal.Beauty.Interface.Models.Parameters.Commons;

namespace Zal.Beauty.WebApp.Areas.Common.Controllers
{
    /// <summary>
    /// 素材管理
    /// </summary>
    [Area("Common")]
    public class FileController:Controller
    {
        public readonly IFileManager manager;
        public FileController(IFileManager manager)
        {
            this.manager = manager;
        }
        /// <summary>
        /// 返回素材管理界面
        /// </summary>
        /// <returns></returns>
        public IActionResult FileIndex()
        {
            return View();
        }
        /// <summary>
        /// 添加素材分类
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddTag(String name,int weight)
        {
            var result = await manager.AddTagAsync(name,weight);
            return Json(result);
        }

        /// <summary>
        /// 返回素材上传界面
        /// </summary>
        /// <returns></returns>
        public IActionResult FileUpload(String tagName)
        {
            return View("FileUpload",tagName);
        }
        /// <summary>
        /// 素材上传OSS
        /// </summary>
        /// <returns></returns>
        public IActionResult UploadOSS(List<IFormFile> file)
        {
            return Json("");
        }
    }
}
