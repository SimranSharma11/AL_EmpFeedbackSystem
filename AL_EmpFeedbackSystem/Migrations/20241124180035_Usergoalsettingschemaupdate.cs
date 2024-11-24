using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AL_EmpFeedbackSystem.Migrations
{
    public partial class Usergoalsettingschemaupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeadComment",
                table: "UserGoalSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadRating",
                table: "UserGoalSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelfComment",
                table: "UserGoalSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelfRating",
                table: "UserGoalSettings",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeadComment",
                table: "UserGoalSettings");

            migrationBuilder.DropColumn(
                name: "LeadRating",
                table: "UserGoalSettings");

            migrationBuilder.DropColumn(
                name: "SelfComment",
                table: "UserGoalSettings");

            migrationBuilder.DropColumn(
                name: "SelfRating",
                table: "UserGoalSettings");
        }
    }
}
