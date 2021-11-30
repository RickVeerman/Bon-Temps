using Microsoft.EntityFrameworkCore.Migrations;

namespace bon_temps.Data.Migrations
{
    public partial class applicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preposition",
                table: "AspNetUsers",
                newName: "Tussenvoegsel");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Achternaam");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "Voornaam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Tussenvoegsel",
                table: "AspNetUsers",
                newName: "Preposition");

            migrationBuilder.RenameColumn(
                name: "Achternaam",
                table: "AspNetUsers",
                newName: "LastName");
        }
    }
}
