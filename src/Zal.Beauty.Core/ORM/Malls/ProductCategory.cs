using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Malls
{
    /// <summary>
    /// 商品分类
    /// </summary>
    [Table("mall_product_categorys")]
    public class ProductCategory
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 一级分类Id
        /// </summary>
        [Column("category1st_id")]
        public long Category1stId { get; set; }

        /// <summary>
        /// 二级分类Id
        /// </summary>
        [Column("category2nd_id")]
        public long Category2ndId { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        [Column("product_id")]
        public long ProductId { get; set; }
    }
}
