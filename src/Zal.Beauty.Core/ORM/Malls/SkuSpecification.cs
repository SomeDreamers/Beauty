using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Malls
{
    /// <summary>
    /// sku与规格关联
    /// </summary>
    [Table("mall_sku_specifications")]
    public class SkuSpecification
    {
        // <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// skuID
        /// </summary>
        [Column("sku_id")]
        public long SkuId { get; set; }

        /// <summary>
        /// 规格ID
        /// </summary>
        [Column("specification_id")]
        public long SpecificationId { get; set; }

        /// <summary>
        /// 规格值ID
        /// </summary>
        [Column("specification_value_id")]
        public long SpecificationValueId { get; set; }
    }
}
