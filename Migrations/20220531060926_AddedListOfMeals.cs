using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Migrations
{
    public partial class AddedListOfMeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diary_Meal_MealId",
                table: "Diary");

            migrationBuilder.DropIndex(
                name: "IX_Diary_MealId",
                table: "Diary");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Diary");

            migrationBuilder.AddColumn<int>(
                name: "DiaryId",
                table: "Meal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meal_DiaryId",
                table: "Meal",
                column: "DiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Diary_DiaryId",
                table: "Meal",
                column: "DiaryId",
                principalTable: "Diary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Diary_DiaryId",
                table: "Meal");

            migrationBuilder.DropIndex(
                name: "IX_Meal_DiaryId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "DiaryId",
                table: "Meal");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Diary",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diary_MealId",
                table: "Diary",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diary_Meal_MealId",
                table: "Diary",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
