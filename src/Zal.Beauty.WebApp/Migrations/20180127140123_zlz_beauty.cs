using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zal.Beauty.WebApp.Migrations
{
    public partial class zlz_beauty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "identity_users",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    address = table.Column<string>(nullable: true),
                    create_time = table.Column<DateTime>(nullable: false),
                    icon = table.Column<string>(nullable: true),
                    mail = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    true_name = table.Column<string>(nullable: true),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identity_users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "identity_users");
        }
    }
}
