using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Zal.Beauty.Core;
using Zal.Beauty.Interface.Enums.Identitys;
using Zal.Beauty.Base.Enums;
using Zal.Beauty.Interface.Enums.Wechats;

namespace Zal.Beauty.WebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5");

            modelBuilder.Entity("Zal.Beauty.Core.ORM.Commons.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<int>("Weight")
                        .HasColumnName("weight");

                    b.HasKey("Id");

                    b.ToTable("common_tags");
                });

            modelBuilder.Entity("Zal.Beauty.Core.ORM.Identitys.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<bool>("IsDel")
                        .HasColumnName("is_del");

                    b.Property<string>("Memo")
                        .HasColumnName("memo");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("identity_roles");
                });

            modelBuilder.Entity("Zal.Beauty.Core.ORM.Identitys.RolePermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("PermissionKey")
                        .HasColumnName("permission_key");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.ToTable("identity_role_permissions");
                });

            modelBuilder.Entity("Zal.Beauty.Core.ORM.Identitys.RoleUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("identity_role_users");
                });

            modelBuilder.Entity("Zal.Beauty.Core.ORM.Identitys.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnName("create_time");

                    b.Property<string>("Icon")
                        .HasColumnName("icon");

                    b.Property<string>("Mail")
                        .HasColumnName("mail");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnName("phone");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<string>("TrueName")
                        .HasColumnName("true_name");

                    b.Property<int>("Type")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("identity_users");
                });

            modelBuilder.Entity("Zal.Beauty.Core.ORM.Wechats.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Icon");

                    b.Property<string>("Nick");

                    b.Property<string>("Openid");

                    b.Property<string>("Province");

                    b.Property<int>("Sex");

                    b.Property<string>("Unionid");

                    b.HasKey("Id");

                    b.ToTable("wechat_customers");
                });

            modelBuilder.Entity("Zal.Beauty.Core.ORM.Wechats.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnName("content");

                    b.Property<long>("FromUserId")
                        .HasColumnName("from_user_id");

                    b.Property<string>("FromUserName")
                        .HasColumnName("from_user_name");

                    b.Property<string>("MediaId")
                        .HasColumnName("media_id");

                    b.Property<string>("PicUrl")
                        .HasColumnName("pic_url");

                    b.Property<long>("ToUserId")
                        .HasColumnName("to_user_id");

                    b.Property<string>("ToUserName")
                        .HasColumnName("to_user_name");

                    b.Property<int>("Type")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("wechat_messages");
                });
        }
    }
}
