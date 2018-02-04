using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zal.Beauty.WebApp.Areas.Identity.Controllers
{
    /// <summary>
    /// 用户controller
    /// </summary>
    [Area("Identity"), Authorize]
    public class UserController : Controller
    {
        public async Task<IActionResult> List()
        {
            return View();
        }
    }
}
