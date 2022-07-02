using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Migrations
{
    public partial class SetToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserGoal_UserGoalId1",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGoal_UserPlan_UserPlanId1",
                table: "UserGoal");

            migrationBuilder.DropIndex(
                name: "IX_UserGoal_UserPlanId1",
                table: "UserGoal");

            migrationBuilder.DropIndex(
                name: "IX_User_UserGoalId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserPlanId1",
                table: "UserGoal");

            migrationBuilder.DropColumn(
                name: "UserGoalId1",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "UserPlanId",
                table: "UserGoal",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserGoalId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGoal_UserPlanId",
                table: "UserGoal",
                column: "UserPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserGoalId",
                table: "User",
                column: "UserGoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserGoal_UserGoalId",
                table: "User",
                column: "UserGoalId",
                principalTable: "UserGoal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGoal_UserPlan_UserPlanId",
                table: "UserGoal",
                column: "UserPlanId",
                principalTable: "UserPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserGoal_UserGoalId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGoal_UserPlan_UserPlanId",
                table: "UserGoal");

            migrationBuilder.DropIndex(
                name: "IX_UserGoal_UserPlanId",
                table: "UserGoal");

            migrationBuilder.DropIndex(
                name: "IX_User_UserGoalId",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "UserPlanId",
                table: "UserGoal",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserPlanId1",
                table: "UserGoal",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserGoalId",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserGoalId1",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGoal_UserPlanId1",
                table: "UserGoal",
                column: "UserPlanId1");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserGoalId1",
                table: "User",
                column: "UserGoalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserGoal_UserGoalId1",
                table: "User",
                column: "UserGoalId1",
                principalTable: "UserGoal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGoal_UserPlan_UserPlanId1",
                table: "UserGoal",
                column: "UserPlanId1",
                principalTable: "UserPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
