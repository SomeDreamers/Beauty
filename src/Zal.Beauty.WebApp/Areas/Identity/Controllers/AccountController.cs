using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Base.Utils;
using Zal.Beauty.Interface.Enums.Identitys;
using Zal.Beauty.Interface.IManager;
using Zal.Beauty.Interface.IManager.Identitys;
using Zal.Beauty.Interface.Models.Parameters;
using Zal.Beauty.Interface.Models.Parameters.Identitys;
using Zal.Beauty.Interface.Models.Results;
using Zal.Beauty.Interface.Models.Results.Identitys;
using Zal.Beauty.WebApp.Configs;

namespace Zal.Beauty.WebApp.Areas.Identity.Controllers
{
    /// <summary>
    /// 身份controller
    /// </summary>
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly IUserManager userManager;
        public AccountController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        /// <summary>
        /// 登录界面
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            var isLogined = HttpContext.User.Identity.IsAuthenticated;
            if (isLogined)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("IdeaCoreUser");
            return RedirectToAction("Login");
        }

        /// <summary>
        /// 注册界面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            var isLogined = HttpContext.User.Identity.IsAuthenticated;
            if (isLogined)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<IActionResult> Register(UserParameter user)
        {
            user.Type = EUserType.Customer;
            user.Status = EUserStatus.Enabled;
            var result = await userManager.RegisterAsync(user);
            //await AddClaim(result.Id, user.Name, user.Type);
            return Json(result);
        }

        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IActionResult> Authenticate(UserParameter user)
        {
            ReturnResult result = new ReturnResult();
            UserResult customer = await userManager.GetUserByExactNameAsync(user.Name);
            if (customer == null || customer.Password != CommonUtil.MD5(user.Password))
            {
                result.IsSuccess = false;
                result.Message = "用户名或密码错误！";
                return Json(result);
            }

            //非管理员无法登录
            if (customer.Type != EUserType.Admin)
            {
                result.IsSuccess = false;
                result.Message = "您不是管理员！";
                return Json(result);
            }

            //禁用管理员无法登录
            if (customer.Status == EUserStatus.Disabled)
            {
                result.IsSuccess = false;
                result.Message = "您管理员身份已被禁用！";
                return Json(result);
            }
            await AddClaim(customer.Id, customer.Name, customer.Type);
            return Json(result);
        }

        /// <summary>
        /// 验证用户名唯一性
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public async Task<bool> VerifyName(string Name)
        {
            var user = await userManager.GetUserByExactNameAsync(Name);
            return user == null;
        }

        public async Task AddClaim(long id, string name, EUserType type)
        {
            //增加身份
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, name, ClaimValueTypes.String), new Claim(ClaimTypes.Role, type.GetDescription(), ClaimValueTypes.String), new Claim(ClaimTypes.Sid, id.ToString(), ClaimValueTypes.String) };
            //增加权限
            var permissionKeys = await userManager.GetPermissionKeysByUserIdAsync(id);
            foreach (var permissionKey in permissionKeys)
            {
                claims.Add(new Claim(ClaimTypes.AuthorizationDecision, permissionKey, ClaimValueTypes.String));
            }
            var userIdentity = new ClaimsIdentity(claims, "IdeaCoreUser");
            var userPrincipal = new ClaimsPrincipal(userIdentity);
            await HttpContext.Authentication.SignInAsync("IdeaCoreUser", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddSeconds(10 * 60),
                    IsPersistent = true,
                    AllowRefresh = false
                });
        }
    }
}
