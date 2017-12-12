using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhyBlog.EF.Migrations
{
    public partial class User1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntity");

            migrationBuilder.RenameTable(
                name: "BaseEntity",
                newName: "TBU_User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBU_User",
                table: "TBU_User",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TBU_User",
                table: "TBU_User");

            migrationBuilder.RenameTable(
                name: "TBU_User",
                newName: "BaseEntity");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntity",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity",
                column: "Id");
        }
    }
}
