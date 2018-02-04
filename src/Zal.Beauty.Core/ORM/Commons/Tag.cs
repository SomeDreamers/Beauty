using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Commons
{
    /// <summary>
    /// 素材分类实体类
    /// </summary>
    [Table("common_tags")]
    public class Tag
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        [Column("name")]
        public String Name { get; set; }
        /// <summary>
        /// 权重
        /// </summary>
        [Column("weight")]
        public int Weight { get; set; }
    }
}
