using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zal.Beauty.Core.ORM.Identitys
{
    /// <summary>
    /// 角色权限
    /// </summary>
    [Table("identity_role_permissions")]
    public class RolePermission
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
        /// 权限key值
        /// </summary>
        [Column("permission_key")]
        public string PermissionKey { get; set; }
    }
}
