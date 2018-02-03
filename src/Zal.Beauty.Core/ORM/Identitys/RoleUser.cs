using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Identitys
{
    /// <summary>
    /// 角色用户
    /// </summary>
    [Table("identity_role_users")]
    public class RoleUser
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Column("role_id")]
        public long RoleId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("user_id")]
        public long UserId { get; set; }
    }
}
