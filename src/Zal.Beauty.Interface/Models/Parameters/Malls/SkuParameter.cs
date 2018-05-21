using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Models.Templates.Malls;

namespace Zal.Beauty.Interface.Models.Parameters.Malls
{
    /// <summary>
    /// sku数据参数
    /// </summary>
    public class SkuParameter : SkuTemplate
    {
        /// <summary>
        /// sku规格集合
        /// </summary>
        public List<SkuSpecificationParameter> SkuSpecifications { get; set; }
    }
}
