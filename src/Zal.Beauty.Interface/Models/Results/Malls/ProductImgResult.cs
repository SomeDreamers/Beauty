using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Models.Templates.Malls;

namespace Zal.Beauty.Interface.Models.Results.Malls
{
    /// <summary>
    /// 商品图片数据结果
    /// </summary>
    public class ProductImgResult : ProductImgTemplate
    {
        /// <summary>
        /// 图片URL
        /// </summary>
        public string Url { get; set; }
    }
}
