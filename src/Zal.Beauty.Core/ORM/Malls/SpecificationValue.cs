using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Malls
{
    /// <summary>
    /// 规格值
    /// </summary>
    [Table("mall_specification_values")]
    public class SpecificationValue
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 规格ID
        /// </summary>
        [Column("specification_id")]
        public long SpecificationId { get; set; }

        /// <summary>
        /// 规格值名
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_del")]
        public bool IsDel { get; set; }
    }
}
