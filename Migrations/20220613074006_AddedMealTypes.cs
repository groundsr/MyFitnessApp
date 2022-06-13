using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Migrations
{
    public partial class AddedMealTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Diary_DiaryId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "Types",
                table: "Meal");

            migrationBuilder.RenameColumn(
                name: "DiaryId",
                table: "Meal",
                newName: "LunchId");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_DiaryId",
                table: "Meal",
                newName: "IX_Meal_LunchId");

            migrationBuilder.AddColumn<int>(
                name: "BreakfastId",
                table: "Meal",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DinnerId",
                table: "Meal",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BreakfastId",
                table: "Diary",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DinnerId",
                table: "Diary",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LunchId",
                table: "Diary",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Breakfast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakfast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dinner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lunch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lunch", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meal_BreakfastId",
                table: "Meal",
                column: "BreakfastId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_DinnerId",
                table: "Meal",
                column: "DinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_BreakfastId",
                table: "Diary",
                column: "BreakfastId");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_DinnerId",
                table: "Diary",
                column: "DinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_LunchId",
                table: "Diary",
                column: "LunchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diary_Breakfast_BreakfastId",
                table: "Diary",
                column: "BreakfastId",
                principalTable: "Breakfast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diary_Dinner_DinnerId",
                table: "Diary",
                column: "DinnerId",
                principalTable: "Dinner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diary_Lunch_LunchId",
                table: "Diary",
                column: "LunchId",
                principalTable: "Lunch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Breakfast_BreakfastId",
                table: "Meal",
                column: "BreakfastId",
                principalTable: "Breakfast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Dinner_DinnerId",
                table: "Meal",
                column: "DinnerId",
                principalTable: "Dinner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Lunch_LunchId",
                table: "Meal",
                column: "LunchId",
                principalTable: "Lunch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diary_Breakfast_BreakfastId",
                table: "Diary");

            migrationBuilder.DropForeignKey(
                name: "FK_Diary_Dinner_DinnerId",
                table: "Diary");

            migrationBuilder.DropForeignKey(
                name: "FK_Diary_Lunch_LunchId",
                table: "Diary");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Breakfast_BreakfastId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Dinner_DinnerId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Lunch_LunchId",
                table: "Meal");

            migrationBuilder.DropTable(
                name: "Breakfast");

            migrationBuilder.DropTable(
                name: "Dinner");

            migrationBuilder.DropTable(
                name: "Lunch");

            migrationBuilder.DropIndex(
                name: "IX_Meal_BreakfastId",
                table: "Meal");

            migrationBuilder.DropIndex(
                name: "IX_Meal_DinnerId",
                table: "Meal");

            migrationBuilder.DropIndex(
                name: "IX_Diary_BreakfastId",
                table: "Diary");

            migrationBuilder.DropIndex(
                name: "IX_Diary_DinnerId",
                table: "Diary");

            migrationBuilder.DropIndex(
                name: "IX_Diary_LunchId",
                table: "Diary");

            migrationBuilder.DropColumn(
                name: "BreakfastId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "DinnerId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "BreakfastId",
                table: "Diary");

            migrationBuilder.DropColumn(
                name: "DinnerId",
                table: "Diary");

            migrationBuilder.DropColumn(
                name: "LunchId",
                table: "Diary");

            migrationBuilder.RenameColumn(
                name: "LunchId",
                table: "Meal",
                newName: "DiaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_LunchId",
                table: "Meal",
                newName: "IX_Meal_DiaryId");

            migrationBuilder.AddColumn<int>(
                name: "Types",
                table: "Meal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Diary_DiaryId",
                table: "Meal",
                column: "DiaryId",
                principalTable: "Diary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
