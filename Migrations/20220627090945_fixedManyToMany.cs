using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Migrations
{
    public partial class fixedManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "CaloriesBurnt",
                table: "Exercise");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Meal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CaloriesBurnt",
                table: "Exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
