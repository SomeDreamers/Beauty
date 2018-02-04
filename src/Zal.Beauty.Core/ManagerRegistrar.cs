using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.Managers.Commons;
using Zal.Beauty.Core.Managers.Identitys;
using Zal.Beauty.Interface.IManager.Commons;
using Zal.Beauty.Interface.IManager.Identitys;

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
            services.AddTransient<IFileManager,FileManager>();
        }
    }
}
