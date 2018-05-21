using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Interface.Models.Templates.Malls
{
    /// <summary>
    /// sku规格数据模板
    /// </summary>
    public class SkuSpecificationTemplate
    {
        // <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// skuID
        /// </summary>
        public long SkuId { get; set; }

        /// <summary>
        /// 规格ID
        /// </summary>
        public long SpecificationId { get; set; }

        /// <summary>
        /// 规格值ID
        /// </summary>
        public long SpecificationValueId { get; set; }
    }
}
