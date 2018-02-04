using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Zal.Beauty.Core;

namespace Zal.Beauty.WebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5");

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
        }
    }
}
