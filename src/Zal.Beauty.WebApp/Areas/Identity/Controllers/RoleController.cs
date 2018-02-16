using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.IManager.Identitys;
using Zal.Beauty.Interface.Models.Parameters.Identitys;

namespace Zal.Beauty.WebApp.Areas.Identity.Controllers
{
    /// <summary>
    /// 角色controller
    /// </summary>
    [Area("Identity"), Authorize]
    public class RoleController : Controller
    {
        private readonly IRoleManager roleManager;
        public RoleController(IRoleManager roleManager)
        {
            this.roleManager = roleManager;
        }

        /// <summary>
        /// 用户角色页面
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> List()
        {
            var roles = await roleManager.GetRoleInfosAsync();
            return View(roles);
        }

        /// <summary>
        /// 删除角色操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(long id)
        {
            var result = await roleManager.DeleteByIdAsync(id);
            return Json(result);
        }

        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(long id)
        {
            var role = await roleManager.GetRoleByIdAsync(id);
            return View("_Edit", role);
        }

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(RoleParameter role)
        {
            var result = await roleManager.SaveAsync(role);
            return Json(result);
        }

        /// <summary>
        /// 角色移除用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IActionResult> RemoveUser(long roleId, long userId)
        {
            var result = await roleManager.RemoveUserOfRoleAsync(roleId, userId);
            return Json(result);
        }

        /// <summary>
        /// 角色添加用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddUser(long roleId, long userId)
        {
            var result = await roleManager.RemoveUserOfRoleAsync(roleId, userId);
            return Json(result);
        }
    }
}
