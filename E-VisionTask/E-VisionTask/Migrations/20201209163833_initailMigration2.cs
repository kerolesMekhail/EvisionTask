using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_VisionTask.Migrations
{
    public partial class initailMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDT",
                table: "Product",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDT",
                table: "Product",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Product",
                type: "Bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Category",
                type: "Bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Cat_Product",
                type: "Bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Cat_Product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDT",
                table: "Product",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDT",
                table: "Product",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
