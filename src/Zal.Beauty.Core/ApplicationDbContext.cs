using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.ORM.Identitys;
using Zal.Beauty.Core.ORM.Wechats;

namespace Zal.Beauty.Core
{
    public class ApplicationDbContext : DbContext
    {
        #region identity
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// 角色用户表
        /// </summary>
        public DbSet<RoleUser> RoleUsers { get; set; }

        /// <summary>
        /// 角色权限表
        /// </summary>
        public DbSet<RolePermission> RolePermissions { get; set; }
        #endregion

        #region wechat
        /// <summary>
        /// 客户表
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// 微信消息表
        /// </summary>
        public DbSet<Message> Messages { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        
    }
}
