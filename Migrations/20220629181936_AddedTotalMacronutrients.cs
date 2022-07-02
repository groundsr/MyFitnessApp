using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Migrations
{
    public partial class AddedTotalMacronutrients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalCarbohydrates",
                table: "Lunch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalFat",
                table: "Lunch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalProtein",
                table: "Lunch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCarbohydrates",
                table: "Dinner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalFat",
                table: "Dinner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalProtein",
                table: "Dinner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCarbohydrates",
                table: "Breakfast",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalFat",
                table: "Breakfast",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalProtein",
                table: "Breakfast",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCarbohydrates",
                table: "Lunch");

            migrationBuilder.DropColumn(
                name: "TotalFat",
                table: "Lunch");

            migrationBuilder.DropColumn(
                name: "TotalProtein",
                table: "Lunch");

            migrationBuilder.DropColumn(
                name: "TotalCarbohydrates",
                table: "Dinner");

            migrationBuilder.DropColumn(
                name: "TotalFat",
                table: "Dinner");

            migrationBuilder.DropColumn(
                name: "TotalProtein",
                table: "Dinner");

            migrationBuilder.DropColumn(
                name: "TotalCarbohydrates",
                table: "Breakfast");

            migrationBuilder.DropColumn(
                name: "TotalFat",
                table: "Breakfast");

            migrationBuilder.DropColumn(
                name: "TotalProtein",
                table: "Breakfast");
        }
    }
}
