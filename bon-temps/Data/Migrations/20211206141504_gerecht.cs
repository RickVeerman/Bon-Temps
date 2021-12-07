using Microsoft.EntityFrameworkCore.Migrations;

namespace bon_temps.Data.Migrations
{
    public partial class gerecht : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gerecht",
                columns: new[] { "Id", "GerechtSoortId", "Naam" },
                values: new object[] { 7, 3, "Soft Ijs" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gerecht",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
