using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Enums.Identitys;
using Zal.Beauty.Interface.IManager.Identitys;
using Zal.Beauty.Interface.Models.Parameters.Identitys;

namespace Zal.Beauty.WebApp.Areas.Identity.Controllers
{
    /// <summary>
    /// 用户controller
    /// </summary>
    [Area("Identity"), Authorize]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// 用户信息界面
        /// </summary> 
        /// <param name="query"></param>
        /// <returns></returns>
        public IActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 用户集合ajax
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IActionResult> UserSetAjax(UserQuery query)
        {
            var userSet = await userManager.GetUserSetAsync(query);
            return Json(userSet);
        }

        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateUserStatus(long id, EUserStatus status)
        {
            var result = await userManager.UpdateUserStatusAsync(id, status);
            return Json(result);
        }

        /// <summary>
        /// 批量更新用户状态
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<IActionResult> BatchUpdateUserStatus(List<long> ids, EUserStatus status)
        {
            ReturnResult result = new ReturnResult();
            foreach (var id in ids)
            {
                result = await userManager.UpdateUserStatusAsync(id, status);
                if (!result.IsSuccess)
                    return Json(result);
            }
            return Json(result);
        }

        /// <summary>
        /// 更新用户类型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateUserType(long id, EUserType type)
        {
            var result = await userManager.UpdateUserTypeAsync(id, type);
            return Json(result);
        }

        /// <summary>
        /// 编辑用户界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(long id)
        {
            var user = await userManager.GetUserByIdAsync(id);
            return PartialView("_Edit", user);
        }
    }
}
