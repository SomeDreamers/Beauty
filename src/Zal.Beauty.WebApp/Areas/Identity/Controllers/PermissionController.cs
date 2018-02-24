using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.IManager.Identitys;

namespace Zal.Beauty.WebApp.Areas.Identity.Controllers
{
    /// <summary>
    /// 权限controller
    /// </summary>
    [Area("Identity"), Authorize]
    public class PermissionController : Controller
    {
        private readonly IRoleManager roleManager;
        private readonly IPermissionManager permissionManger;
        public PermissionController(IRoleManager roleManager, IPermissionManager permissionManger)
        {
            this.roleManager = roleManager;
            this.permissionManger = permissionManger;
        }

        /// <summary>
        /// 权限管理
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.GetRolesAsync();
            return View(roles);
        }

        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetRolePermissions(long roleId)
        {
            var rolePermissions = await permissionManger.GetPermissionsByRoleIdAsync(roleId);
            return Json(rolePermissions);
        }

        /// <summary>
        /// 更新角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateRolePermissions(long roleId, List<string> permissionKeys)
        {
            var result = await permissionManger.UpdateRolePermissionsAsync(roleId, permissionKeys);
            return Json(result);
        }
    }
}
