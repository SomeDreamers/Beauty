using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Models.Templates.Identitys;

namespace Zal.Beauty.Interface.Models.Results.Identitys
{
    /// <summary>
    /// 角色信息（包含角色用户）
    /// </summary>
    public class RoleInfoResult : RoleTemplate
    {
        /// <summary>
        /// 角色下用户信息
        /// </summary>
        public List<UserResult> Users { get; set; }
    }
}
