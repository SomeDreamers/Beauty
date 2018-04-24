using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Malls
{
    /// <summary>
    /// 商品标签
    /// </summary>
    [Table("mall_product_tags")]
    public class ProductTag
    {
        // <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [Column("product_id")]
        public long ProductId { get; set; }

        /// <summary>
        /// 标签ID
        /// </summary>
        [Column("tag_id")]
        public long TagId { get; set; }
    }
}
