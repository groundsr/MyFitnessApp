using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Migrations
{
    public partial class ChangedManyToManyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "LunchMeals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "ActualProtein",
                table: "LunchMeals",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "ActualFat",
                table: "LunchMeals",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "ActualCarbs",
                table: "LunchMeals",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "ActualCalories",
                table: "LunchMeals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Lunch",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "DinnerMeals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "ActualProtein",
                table: "DinnerMeals",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "ActualFat",
                table: "DinnerMeals",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "ActualCarbs",
                table: "DinnerMeals",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "ActualCalories",
                table: "DinnerMeals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Dinner",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lunch_MealId",
                table: "Lunch",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Dinner_MealId",
                table: "Dinner",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dinner_Meal_MealId",
                table: "Dinner",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lunch_Meal_MealId",
                table: "Lunch",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dinner_Meal_MealId",
                table: "Dinner");

            migrationBuilder.DropForeignKey(
                name: "FK_Lunch_Meal_MealId",
                table: "Lunch");

            migrationBuilder.DropIndex(
                name: "IX_Lunch_MealId",
                table: "Lunch");

            migrationBuilder.DropIndex(
                name: "IX_Dinner_MealId",
                table: "Dinner");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Lunch");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Dinner");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "LunchMeals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ActualProtein",
                table: "LunchMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "ActualFat",
                table: "LunchMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "ActualCarbs",
                table: "LunchMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "ActualCalories",
                table: "LunchMeals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "DinnerMeals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ActualProtein",
                table: "DinnerMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "ActualFat",
                table: "DinnerMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "ActualCarbs",
                table: "DinnerMeals",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "ActualCalories",
                table: "DinnerMeals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
