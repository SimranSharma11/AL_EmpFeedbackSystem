using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AL_EmpFeedbackSystem.Migrations
{
    public partial class DurationIdremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationId",
                table: "Durations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationId",
                table: "Durations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
