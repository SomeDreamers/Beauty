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
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 客户表
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// 微信消息表
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        
    }
}
