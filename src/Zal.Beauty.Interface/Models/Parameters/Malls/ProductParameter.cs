using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Models.Templates.Malls;

namespace Zal.Beauty.Interface.Models.Parameters.Malls
{
    /// <summary>
    /// 商品参数
    /// </summary>
    public class ProductParameter : ProductTemplate
    {
        /// <summary>
        /// 商品图片
        /// </summary>
        public List<ProductImgParameter> Imgs { get; set; }

        /// <summary>
        /// 商品标签
        /// </summary>
        public List<ProductTagParameter> Tags { get; set; }
 
        /// <summary>
        /// sku集合
        /// </summary>
        public List<SkuParameter> Skus { get; set; }
    }
}
