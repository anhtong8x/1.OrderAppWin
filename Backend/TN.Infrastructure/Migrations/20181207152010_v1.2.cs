using Microsoft.EntityFrameworkCore.Migrations;

namespace TN.Infrastructure.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "DishPrice",
                newName: "CreateDate");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "DishPrice",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "DishPrice");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "DishPrice",
                newName: "Date");
        }
    }
}
