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
    /// 品牌接口
    /// </summary>
    public interface IBrandManager
    {
        /// <summary>
        /// 保存品牌
        /// </summary>
        /// <returns></returns>
        Task<ReturnResult> SaveAsync(BrandParameter parameter);

        /// <summary>
        /// 获取所有品牌
        /// </summary>
        /// <returns></returns>
        Task<List<BrandResult>> GetAllBrandsAsync();
    }
}
