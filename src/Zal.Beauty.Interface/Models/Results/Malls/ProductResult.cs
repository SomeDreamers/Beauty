using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Models.Templates.Malls;

namespace Zal.Beauty.Interface.Models.Results.Malls
{
    /// <summary>
    /// 商品数据结果
    /// </summary>
    public class ProductResult : ProductTemplate
    {
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }
    }
}
