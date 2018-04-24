using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Models.Parameters.Malls;
using Zal.Beauty.Interface.Models.Results.Malls;

namespace Zal.Beauty.Interface.IManager.Malls
{
    /// <summary>
    /// 商品标签接口
    /// </summary>
    public interface ITagManager
    {
        /// <summary>
        /// 保存商品标签
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<ReturnResult> SaveAsync(TagParameter parameter);

        /// <summary>
        /// 获取所有标签 
        /// </summary>
        /// <returns></returns>
        Task<List<TagResult>> GetAllTagsAsync();
    }
}
