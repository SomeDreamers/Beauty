using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.ORM.Commons;
using Zal.Beauty.Interface.IManager.Commons;
using Zal.Beauty.Interface.Models.Parameters.Commons;
using Zal.Beauty.Interface.Models.Results.Commons;

namespace Zal.Beauty.Core.Managers.Commons
{
    /// <summary>
    /// 素材分类管理
    /// </summary>
    public class FileManager : IFileManager
    {
        public readonly ApplicationDbContext context;
        public FileManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 上传素材
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task AddFileAsync(FileParameter file)
        {
            var fileEntity = Mapper.Map<File>(file);
            await context.Files.AddAsync(fileEntity);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// 获取全部素材分类
        /// </summary>
        /// <returns></returns>
        public async Task<List<TagResult>> GetTagAllAsync()
        {
            var tag = await context.Tags.OrderBy(c=>c.Weight).ToListAsync();
            if (tag == null) return null;
            return Mapper.Map<List<TagResult>>(tag);
        }
        /// <summary>
        /// 增加素材分类
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<ReturnResult> AddTagAsync(String name, int weight)
        {
            ReturnResult result = new ReturnResult();
            TagParameter tag = new TagParameter();
            tag.Weight=weight;
            tag.Name = name;
            var fileEntity = Mapper.Map<Tag>(tag);
            await context.Tags.AddAsync(fileEntity);
            await context.SaveChangesAsync();
            result.IsSuccess = true;
            return result;
        }

        /// <summary>
        ///根据素材分类ID获取全部素材
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task<List<FileResult>> GetAllFileAsync(long tagId)
        {
            var files = await context.Files.Where(c => c.TagId == tagId&&c.IsDel==false).OrderByDescending(c => c.CreateTime).ToListAsync();
            List<FileResult> list = Mapper.Map<List<FileResult>>(files);
            return list;
        }

        /// <summary>
        /// 根据OSSkey判断素材是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<int> GetFileCountByOssKey(String key)
        {
            var count = await context.Files.CountAsync(c => c.OssKey == key);
            return count;
        }

        /// <summary>
        /// 更新素材创建时间
        /// </summary>
        /// <returns></returns>
        public async Task UpdateTime(String osskey)
        {
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var file=await context.Files.FirstAsync(c => c.OssKey == osskey);
            file.CreateTime = time;
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 修改素材名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task ModifyFileName(long id,String name)
        {
            var file = await context.Files.FirstAsync(c=>c.Id==id);
            file.Name = name;
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// 删除素材
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteFile(long id)
        {
            var file =await context.Files.FirstAsync(c=>c.Id==id);
            file.IsDel = true;
            await context.SaveChangesAsync();
        }
    }
}
