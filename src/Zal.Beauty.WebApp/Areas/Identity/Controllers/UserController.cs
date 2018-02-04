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
        public async Task<IActionResult> List(UserQuery query)
        {
            var userSet = await userManager.GetUserSetAsync(query);
            return View(userSet);
        }
    }
}
