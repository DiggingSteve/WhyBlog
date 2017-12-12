using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhyBlog.EF.Migrations
{
    public partial class useracc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Account",
                table: "TBU_User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pwd",
                table: "TBU_User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account",
                table: "TBU_User");

            migrationBuilder.DropColumn(
                name: "Pwd",
                table: "TBU_User");
        }
    }
}
