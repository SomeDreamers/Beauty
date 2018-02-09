using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.IManager.Identitys;

namespace Zal.Beauty.WebApp.Areas.Identity.Controllers
{
    /// <summary>
    /// 角色controller
    /// </summary>
    public class RoleController : Controller
    {
        private readonly IRoleManager roleManager;
        public RoleController()
        {

        }

        /// <summary>
        /// 用户角色页面
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> List()
        {
            return View();
        }
    }
}
