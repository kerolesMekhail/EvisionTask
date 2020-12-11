using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_VisionTask.Migrations
{
    public partial class edittypephoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Product",
                nullable: true);
        }
    }
}
