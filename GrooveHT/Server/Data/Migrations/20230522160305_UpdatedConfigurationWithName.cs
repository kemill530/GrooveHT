using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrooveHT.Server.Data.Migrations
{
    public partial class UpdatedConfigurationWithName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "StartDate",
                table: "Configurations",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Configurations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Configurations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }
    }
}
