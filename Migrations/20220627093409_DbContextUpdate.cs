using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Migrations
{
    public partial class DbContextUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakfastMeals",
                columns: table => new
                {
                    BreakfastId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastMeals", x => new { x.BreakfastId, x.MealId });
                    table.ForeignKey(
                        name: "FK_BreakfastMeals_Breakfast_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreakfastMeals_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaryExercises",
                columns: table => new
                {
                    DiaryId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    HowLong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryExercises", x => new { x.DiaryId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_DiaryExercises_Diary_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "Diary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiaryExercises_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DinnerMeals",
                columns: table => new
                {
                    DinnerId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinnerMeals", x => new { x.DinnerId, x.MealId });
                    table.ForeignKey(
                        name: "FK_DinnerMeals_Dinner_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DinnerMeals_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LunchMeals",
                columns: table => new
                {
                    LunchId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchMeals", x => new { x.LunchId, x.MealId });
                    table.ForeignKey(
                        name: "FK_LunchMeals_Lunch_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LunchMeals_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastMeals_MealId",
                table: "BreakfastMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryExercises_ExerciseId",
                table: "DiaryExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerMeals_MealId",
                table: "DinnerMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchMeals_MealId",
                table: "LunchMeals",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakfastMeals");

            migrationBuilder.DropTable(
                name: "DiaryExercises");

            migrationBuilder.DropTable(
                name: "DinnerMeals");

            migrationBuilder.DropTable(
                name: "LunchMeals");
        }
    }
}
