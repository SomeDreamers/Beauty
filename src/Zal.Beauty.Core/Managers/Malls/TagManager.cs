using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.ORM.Malls;
using Zal.Beauty.Interface.IManager.Malls;
using Zal.Beauty.Interface.Models.Parameters.Malls;
using Zal.Beauty.Interface.Models.Results.Malls;

namespace Zal.Beauty.Core.Managers.Malls
{
    /// <summary>
    /// 商品标签manager
    /// </summary>
    public class TagManager : ITagManager
    {
        private readonly ApplicationDbContext context;
        public TagManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 保存商品标签
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ReturnResult> SaveAsync(TagParameter parameter)
        {
            ReturnResult result = new ReturnResult();
            var tag = Mapper.Map<Tag>(parameter);
            //验证标签名称
            tag.Name = tag.Name?.Trim();
            if (string.IsNullOrEmpty(tag.Name))
            {
                result.IsSuccess = false;
                result.Message = "标签名称不能为空";
                return result;
            }
            //新建保存标签
            if (tag.Id <= 0)
            {
                //验证标签名称是否重复
                var tmpTag = await context.ProTags.FirstOrDefaultAsync(c => c.Name == tag.Name);
                if(tmpTag != null)
                {
                    result.IsSuccess = false;
                    result.Message = "标签名称重复";
                    return result;
                }
                //设置创建时间
                if (tag.CreateTime == DateTime.MinValue)
                    tag.CreateTime = DateTime.Now;
                //创建标签
                await context.ProTags.AddAsync(tag);
                result.Id = tag.Id;
            }
            //编辑保存标签
            else
            {
                var oldTag = await context.ProTags.FirstOrDefaultAsync(c => c.Id == tag.Id);
                if(oldTag == null || oldTag.IsDel)
                {
                    result.IsSuccess = false;
                    result.Message = "标签已被删除";
                    return result;
                }
                //验证标签名称是否重复
                var tmpTag = await context.ProTags.FirstOrDefaultAsync(c => c.Name == tag.Name);
                if (tmpTag != null && tmpTag.Id != oldTag.Id)
                {
                    result.IsSuccess = false;
                    result.Message = "标签名称重复";
                    return result;
                }
                //更新标签
                oldTag.Name = tag.Name;
                oldTag.Style = tag.Style;
                context.ProTags.Update(oldTag);
            }
            await context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 获取所有标签
        /// </summary>
        /// <returns></returns>
        public async Task<List<TagResult>> GetAllTagsAsync()
        {
            var tags = await context.ProTags.ToListAsync();
            return Mapper.Map<List<TagResult>>(tags);
        }
    }
}
