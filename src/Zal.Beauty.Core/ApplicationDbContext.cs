using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.ORM.Commons;
using Zal.Beauty.Core.ORM.Identitys;
using Zal.Beauty.Core.ORM.Malls;
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

        #region mall
        /// <summary>
        /// 品牌表
        /// </summary>
        /// <param name="options"></param>
        public DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// 商品表
        /// </summary>
        /// <param name="options"></param>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// 商品图片关联表
        /// </summary>
        /// <param name="options"></param>
        public DbSet<ProductImg> ProductImgs { get; set; }

        /// <summary>
        /// 商品标签关联表
        /// </summary>
        /// <param name="options"></param>
        public DbSet<ProductTag> ProductTags { get; set; }

        /// <summary>
        /// sku表
        /// </summary>
        /// <param name="options"></param>
        public DbSet<Sku> Skus { get; set; }

        /// <summary>
        /// sku规格关联表
        /// </summary>
        /// <param name="options"></param>
        public DbSet<SkuSpecification> SkuSpecifications { get; set; }

        /// <summary>
        /// 规格表
        /// </summary>
        /// <param name="options"></param>
        public DbSet<Specification> Specifications { get; set; }

        /// <summary>
        /// 规格值表
        /// </summary>
        /// <param name="options"></param>
        public DbSet<SpecificationValue> SpecificationValues { get; set; }

        /// <summary>
        /// 商品分类
        /// </summary>
        public DbSet<Category> Categorys { get; set; } 

        /// <summary>
        /// 商品标签表
        /// </summary>
        /// <param name="options"></param>
        public DbSet<ORM.Malls.Tag> ProTags { get; set; }
        #endregion

        /// <summary>
        /// 素材分类表
        /// </summary>
        /// <param name="options"></param>
        public DbSet<ORM.Commons.Tag> Tags { get; set; }
        /// <summary>
        /// 素材表
        /// </summary>
        public DbSet<File> Files { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


    }
}