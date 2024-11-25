using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AL_EmpFeedbackSystem.Migrations
{
    public partial class SubGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserGoalSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubGoal",
                table: "UserGoalSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserGoalSettings");

            migrationBuilder.DropColumn(
                name: "SubGoal",
                table: "UserGoalSettings");
        }
    }
}
