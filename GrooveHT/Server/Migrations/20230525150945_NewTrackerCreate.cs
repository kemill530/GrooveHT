using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrooveHT.Server.Migrations
{
    public partial class NewTrackerCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trackers_Frequencies_FrequencyId",
                table: "Trackers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trackers_Habits_HabitId",
                table: "Trackers");

            migrationBuilder.DropIndex(
                name: "IX_Trackers_FrequencyId",
                table: "Trackers");

            migrationBuilder.DropIndex(
                name: "IX_Trackers_HabitId",
                table: "Trackers");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "Trackers");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "Trackers");

            migrationBuilder.DropColumn(
                name: "FrequencyType",
                table: "Trackers");

            migrationBuilder.DropColumn(
                name: "HabitId",
                table: "Trackers");

            migrationBuilder.DropColumn(
                name: "HabitName",
                table: "Trackers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfigId",
                table: "Trackers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                table: "Trackers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FrequencyType",
                table: "Trackers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HabitId",
                table: "Trackers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HabitName",
                table: "Trackers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Trackers_FrequencyId",
                table: "Trackers",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Trackers_HabitId",
                table: "Trackers",
                column: "HabitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trackers_Frequencies_FrequencyId",
                table: "Trackers",
                column: "FrequencyId",
                principalTable: "Frequencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trackers_Habits_HabitId",
                table: "Trackers",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
