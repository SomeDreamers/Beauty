﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Zal.Beauty.Core;
using Microsoft.AspNetCore.Http;
using Zal.Beauty.WebApp;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Zal.Beauty.WebApp.Configs;
using System;
using System.Reflection;

namespace Beauty
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //注入数据库上下文
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Zal.Beauty.WebApp")));
            // Add framework services.
            services.AddMvc();
            //权限注入
            services.AddAuthorization(options =>
            {
                Type type = typeof(PermissionKeys);
                FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                foreach (FieldInfo fi in fieldInfos)
                {
                    var permissionKey = fi.GetValue(null).ToString();
                    options.AddPolicy(permissionKey, policy => policy.RequireClaim(ClaimTypes.AuthorizationDecision, permissionKey));
                }
            });
            //注入manager
            ManagerRegistrar.RegistManager(services);
            //初始化映射配置
            MapperInitializer.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //设置权限
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "IdeaCoreUser",
                LoginPath = new PathString("/Identity/Account/Login/"),
                AccessDeniedPath = new PathString("/Identity/Account/Forbidden/"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
