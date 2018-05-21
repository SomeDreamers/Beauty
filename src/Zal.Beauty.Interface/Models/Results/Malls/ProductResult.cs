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
        /// 主图URL
        /// </summary>
        public string MainImgUrl { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public List<ProductImgResult> Imgs { get; set; }
    }
}
