using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Migrations
{
    public partial class CheckBreakfast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakfastMeal");

            migrationBuilder.DropTable(
                name: "DiaryExercise");

            migrationBuilder.DropTable(
                name: "DinnerMeal");

            migrationBuilder.DropTable(
                name: "LunchMeal");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
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

            migrationBuilder.AlterColumn<int>(
                name: "HowLong",
                table: "DiaryExercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "BreakfastMeals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "LunchMeals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "DinnerMeals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HowLong",
                table: "DiaryExercises",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "BreakfastMeals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BreakfastMeal",
                columns: table => new
                {
                    BreakfastsId = table.Column<int>(type: "int", nullable: false),
                    MealsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastMeal", x => new { x.BreakfastsId, x.MealsId });
                    table.ForeignKey(
                        name: "FK_BreakfastMeal_Breakfast_BreakfastsId",
                        column: x => x.BreakfastsId,
                        principalTable: "Breakfast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreakfastMeal_Meal_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaryExercise",
                columns: table => new
                {
                    DiariesId = table.Column<int>(type: "int", nullable: false),
                    ExercisesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryExercise", x => new { x.DiariesId, x.ExercisesId });
                    table.ForeignKey(
                        name: "FK_DiaryExercise_Diary_DiariesId",
                        column: x => x.DiariesId,
                        principalTable: "Diary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiaryExercise_Exercise_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DinnerMeal",
                columns: table => new
                {
                    DinnersId = table.Column<int>(type: "int", nullable: false),
                    MealsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinnerMeal", x => new { x.DinnersId, x.MealsId });
                    table.ForeignKey(
                        name: "FK_DinnerMeal_Dinner_DinnersId",
                        column: x => x.DinnersId,
                        principalTable: "Dinner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DinnerMeal_Meal_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LunchMeal",
                columns: table => new
                {
                    LunchesId = table.Column<int>(type: "int", nullable: false),
                    MealsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchMeal", x => new { x.LunchesId, x.MealsId });
                    table.ForeignKey(
                        name: "FK_LunchMeal_Lunch_LunchesId",
                        column: x => x.LunchesId,
                        principalTable: "Lunch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LunchMeal_Meal_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastMeal_MealsId",
                table: "BreakfastMeal",
                column: "MealsId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryExercise_ExercisesId",
                table: "DiaryExercise",
                column: "ExercisesId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerMeal_MealsId",
                table: "DinnerMeal",
                column: "MealsId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchMeal_MealsId",
                table: "LunchMeal",
                column: "MealsId");
        }
    }
}
