using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.ORM.Commons;
using Zal.Beauty.Interface.IManager.Commons;
using Zal.Beauty.Interface.Models.Parameters.Commons;

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
    }
}
