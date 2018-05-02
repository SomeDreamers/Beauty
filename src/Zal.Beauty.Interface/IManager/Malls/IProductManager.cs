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
    /// 商品管理接口
    /// </summary>
    public interface IProductManager
    {
        /// <summary>
        /// 获取商品集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<EntitySet<ProductResult>> GetProductSetAsync(ProductQuery queryParameter);
    }
}
