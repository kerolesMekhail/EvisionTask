using Microsoft.EntityFrameworkCore.Migrations;

namespace E_VisionTask.Migrations
{
    public partial class edittypephoto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Product");
        }
    }
}
