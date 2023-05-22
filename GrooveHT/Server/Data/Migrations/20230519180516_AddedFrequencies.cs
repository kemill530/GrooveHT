using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrooveHT.Server.Data.Migrations
{
    public partial class AddedFrequencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                table: "Configurations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_FrequencyId",
                table: "Configurations",
                column: "FrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Frequencies_FrequencyId",
                table: "Configurations",
                column: "FrequencyId",
                principalTable: "Frequencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Frequencies_FrequencyId",
                table: "Configurations");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropIndex(
                name: "IX_Configurations_FrequencyId",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "Configurations");
        }
    }
}
