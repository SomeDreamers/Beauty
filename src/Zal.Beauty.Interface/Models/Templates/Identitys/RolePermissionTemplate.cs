using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Interface.Models.Templates.Identitys
{
    /// <summary>
    /// 角色权限数据模板
    /// </summary>
    public class RolePermissionTemplate
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }

        /// <summary>
        /// 权限key值
        /// </summary>
        public string PermissionKey { get; set; }
    }
}
