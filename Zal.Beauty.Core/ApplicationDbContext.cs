using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Core
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// 用户表
        /// </summary>
        //public DbSet<User> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
