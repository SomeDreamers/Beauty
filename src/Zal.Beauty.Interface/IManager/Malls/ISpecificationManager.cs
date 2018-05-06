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
    /// 规格接口
    /// </summary>
    public interface ISpecificationManager
    {
        /// <summary>
        /// 保存规格
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<ReturnResult> SaveAsync(SpecificationParameter parameter);

        /// <summary>
        /// 获取所有规格
        /// </summary>
        /// <returns></returns>
        Task<List<SpecificationResult>> GetAllSpecificationsAsync();
    }
}
