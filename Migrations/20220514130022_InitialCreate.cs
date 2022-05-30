using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MyFitnessApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaloriesBurnt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Types = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false),
                    Carbohydrates = table.Column<int>(type: "int", nullable: false),
                    Fat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BMI = table.Column<int>(type: "int", nullable: false),
                    TotalCalories = table.Column<int>(type: "int", nullable: false),
                    TotalCarbs = table.Column<int>(type: "int", nullable: false),
                    TotalProtein = table.Column<int>(type: "int", nullable: false),
                    TotalFat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGoal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goal = table.Column<int>(type: "int", nullable: false),
                    GoalWeight = table.Column<int>(type: "int", nullable: false),
                    GoalPerWeek = table.Column<float>(type: "real", nullable: false),
                    UserActivity = table.Column<int>(type: "int", nullable: false),
                    UserPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGoal_UserPlan_UserPlanId",
                        column: x => x.UserPlanId,
                        principalTable: "UserPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    UserGoalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserGoal_UserGoalId",
                        column: x => x.UserGoalId,
                        principalTable: "UserGoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    MealId = table.Column<int>(type: "int", nullable: true),
                    TotalCalories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diary_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diary_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diary_MealId",
                table: "Diary",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_UserId",
                table: "Diary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserGoalId",
                table: "User",
                column: "UserGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGoal_UserPlanId",
                table: "UserGoal",
                column: "UserPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diary");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "UserGoal");

            migrationBuilder.DropTable(
                name: "UserPlan");
        }
    }
}
