using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Migrations
{
    public partial class AddedDiaryExerciseConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiaryId",
                table: "Exercise",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_DiaryId",
                table: "Exercise",
                column: "DiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Diary_DiaryId",
                table: "Exercise",
                column: "DiaryId",
                principalTable: "Diary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Diary_DiaryId",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_DiaryId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "DiaryId",
                table: "Exercise");
        }
    }
}
