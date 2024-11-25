using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AL_EmpFeedbackSystem.Migrations
{
    public partial class goalreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserGoalSettings_GoalId",
                table: "UserGoalSettings",
                column: "GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGoalSettings_Goals_GoalId",
                table: "UserGoalSettings",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGoalSettings_Goals_GoalId",
                table: "UserGoalSettings");

            migrationBuilder.DropIndex(
                name: "IX_UserGoalSettings_GoalId",
                table: "UserGoalSettings");
        }
    }
}
