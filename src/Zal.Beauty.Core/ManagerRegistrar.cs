using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.Managers.Commons;
using Zal.Beauty.Core.Managers.Identitys;
using Zal.Beauty.Core.Managers.Malls;
using Zal.Beauty.Core.Managers.Wechats;
using Zal.Beauty.Interface.IManager.Commons;
using Zal.Beauty.Interface.IManager.Identitys;
using Zal.Beauty.Interface.IManager.Malls;
using Zal.Beauty.Interface.IManager.Wechats;

namespace Zal.Beauty.Core
{
    /// <summary>
    /// manager注册器
    /// </summary>
    public static class ManagerRegistrar
    {
        public static void RegistManager(this IServiceCollection services)
        {
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IRoleManager, RoleManager>();
            services.AddTransient<IPermissionManager, PermissionManager>();
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<IMessageManager, MessageManager>();
            services.AddTransient<IFileManager,FileManager>();
            #region Mall
            services.AddTransient<IBrandManager, BrandManager>();
            #endregion

        }
    }
}
