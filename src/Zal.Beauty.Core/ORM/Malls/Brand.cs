using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Malls
{
    /// <summary>
    /// 商品品牌
    /// </summary>
    [Table("mall_brands")]
    public class Brand
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 品牌名
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_del")]
        public bool IsDel { get; set; }
    }
}
