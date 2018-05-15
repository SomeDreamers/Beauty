using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Malls
{
    /// <summary>
    /// 商品分类
    /// </summary>
    [Table("mall_categorys")]
    public class Category
    {
        /// <summary>
        /// 商品分类Id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        [Column("parent_id")]
        public long ParentId { get; set; }

        /// <summary>
        /// 商品分类名称
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        [Column("weight")]
        public int Weight { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_del")]
        public Boolean IsDel { get; set; }
    }
}
