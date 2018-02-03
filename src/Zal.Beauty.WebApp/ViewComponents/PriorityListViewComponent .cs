using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Beauty.Interface.IManager.Identitys;
using Zal.Beauty.WebApp.Configs;

namespace Zal.Beauty.WebApp.ViewComponents
{
    /// <summary>
    /// 左边导航栏视图组件
    /// </summary>
    public class PriorityListViewComponent : ViewComponent
    {
        private readonly IUserManager usermanager;

        public PriorityListViewComponent(IUserManager usermanager)
        {
            this.usermanager = usermanager;
        }

        public async Task<IViewComponentResult> InvokeAsync(long userId)
        {
            var permissionKeys = await usermanager.GetPermissionKeysByUserIdAsync(userId);
            return View(permissionKeys);
        }
    }
}
