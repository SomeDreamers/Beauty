using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.Models.Results.Malls;

namespace Zal.Beauty.WebApp.Areas.Mall.ViewModels
{
    /// <summary>
    /// 创建商品所需model
    /// </summary>
    public class CreateProductModel
    {
        /// <summary>
        /// 品牌集合
        /// </summary>
        public List<BrandResult> Brands { get; set; }

        /// <summary>
        /// 标签集合
        /// </summary>
        public List<TagResult> Tags { get; set; }

        /// <summary>
        /// 规格集合
        /// </summary>
        public List<SpecificationResult> Specifications { get; set; }
    }
}
