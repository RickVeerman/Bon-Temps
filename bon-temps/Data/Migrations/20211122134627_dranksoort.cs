using Microsoft.EntityFrameworkCore.Migrations;

namespace bon_temps.Data.Migrations
{
    public partial class dranksoort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DrankSoort",
                columns: new[] { "Id", "Soort" },
                values: new object[,]
                {
                    { 1, "Warme Dranken" },
                    { 2, "Koude Dranken" },
                    { 3, "Bieren" },
                    { 4, "Wijnen" },
                    { 5, "Sterke Dranken" },
                    { 6, "Gemixte Dranken" }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "MenuSoortId", "Naam", "Prijs" },
                values: new object[,]
                {
                    { 2, 1, "Taartmenu", 10m },
                    { 3, 2, "Seizoensmenu", 23m },
                    { 4, 2, "Kerstmenu", 28m }
                });

            migrationBuilder.InsertData(
                table: "Drank",
                columns: new[] { "Id", "DrankSoortId", "Naam", "Prijs" },
                values: new object[,]
                {
                    { 4, 1, "Koffie", 1.5 },
                    { 3, 2, "Colca Cola", 2.2000000000000002 },
                    { 1, 3, "Heineken", 2.7999999999999998 },
                    { 2, 4, "Chardonnay", 4.5 },
                    { 5, 5, "Campari", 2.5 },
                    { 6, 6, "Bacardi Cola", 6.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drank",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drank",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drank",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drank",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Drank",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Drank",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DrankSoort",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DrankSoort",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DrankSoort",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DrankSoort",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DrankSoort",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DrankSoort",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
