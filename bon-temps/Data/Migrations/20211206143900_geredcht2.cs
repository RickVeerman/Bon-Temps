using Microsoft.EntityFrameworkCore.Migrations;

namespace bon_temps.Data.Migrations
{
    public partial class geredcht2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Gerecht",
                keyColumn: "Id",
                keyValue: 1,
                column: "Naam",
                value: "Uiensoep");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Gerecht",
                keyColumn: "Id",
                keyValue: 1,
                column: "Naam",
                value: "UienSoep");
        }
    }
}
