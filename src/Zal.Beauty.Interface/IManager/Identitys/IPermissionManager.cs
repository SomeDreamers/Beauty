using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Models.Results.Identitys;

namespace Zal.Beauty.Interface.IManager.Identitys
{
    /// <summary>
    /// 权限管理接口
    /// </summary>
    public interface IPermissionManager
    {
        /// <summary>
        /// 根据角色ID获取权限信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<RolePermissionResult>> GetPermissionsByRoleIdAsync(long roleId);

        /// <summary>
        /// 更新角色权限
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<ReturnResult> UpdateRolePermissionsAsync(long roleId, List<string> permissionKeys);
    }
}
