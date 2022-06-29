using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Migrations
{
    public partial class PercentageForCalories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActualCalories",
                table: "LunchMeals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ActualCarbs",
                table: "LunchMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ActualFat",
                table: "LunchMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ActualProtein",
                table: "LunchMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ActualCalories",
                table: "DinnerMeals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ActualCarbs",
                table: "DinnerMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ActualFat",
                table: "DinnerMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ActualProtein",
                table: "DinnerMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ActualCalories",
                table: "BreakfastMeals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ActualCarbs",
                table: "BreakfastMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ActualFat",
                table: "BreakfastMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ActualProtein",
                table: "BreakfastMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualCalories",
                table: "LunchMeals");

            migrationBuilder.DropColumn(
                name: "ActualCarbs",
                table: "LunchMeals");

            migrationBuilder.DropColumn(
                name: "ActualFat",
                table: "LunchMeals");

            migrationBuilder.DropColumn(
                name: "ActualProtein",
                table: "LunchMeals");

            migrationBuilder.DropColumn(
                name: "ActualCalories",
                table: "DinnerMeals");

            migrationBuilder.DropColumn(
                name: "ActualCarbs",
                table: "DinnerMeals");

            migrationBuilder.DropColumn(
                name: "ActualFat",
                table: "DinnerMeals");

            migrationBuilder.DropColumn(
                name: "ActualProtein",
                table: "DinnerMeals");

            migrationBuilder.DropColumn(
                name: "ActualCalories",
                table: "BreakfastMeals");

            migrationBuilder.DropColumn(
                name: "ActualCarbs",
                table: "BreakfastMeals");

            migrationBuilder.DropColumn(
                name: "ActualFat",
                table: "BreakfastMeals");

            migrationBuilder.DropColumn(
                name: "ActualProtein",
                table: "BreakfastMeals");
        }
    }
}
