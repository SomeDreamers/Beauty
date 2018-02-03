using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Identitys
{
    /// <summary>
    /// 角色
    /// </summary>
    [Table("identity_roles")]
    public class Role
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 角色备注
        /// </summary>
        [Column("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_del")]
        public bool IsDel { get; set; }
    }
}
