using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.ORM.Commons;
using Zal.Beauty.Core.ORM.Identitys;

namespace Zal.Beauty.Core
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 素材分类表
        /// </summary>
        /// <param name="options"></param>
        public DbSet<Tag> Tags { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        
    }
}
