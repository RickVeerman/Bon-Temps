using Microsoft.EntityFrameworkCore.Migrations;

namespace bon_temps.Data.Migrations
{
    public partial class klant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservering_Klant_KlantId",
                table: "Reservering");

            migrationBuilder.DropIndex(
                name: "IX_Reservering_KlantId",
                table: "Reservering");

            migrationBuilder.DropColumn(
                name: "KlantId",
                table: "Reservering");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Klant",
                newName: "Voornaam");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Reservering",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Achternaam",
                table: "Klant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Klant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tussenvoegsel",
                table: "Klant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Klant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_ApplicationUserId",
                table: "Reservering",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservering_AspNetUsers_ApplicationUserId",
                table: "Reservering",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservering_AspNetUsers_ApplicationUserId",
                table: "Reservering");

            migrationBuilder.DropIndex(
                name: "IX_Reservering_ApplicationUserId",
                table: "Reservering");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Reservering");

            migrationBuilder.DropColumn(
                name: "Achternaam",
                table: "Klant");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Klant");

            migrationBuilder.DropColumn(
                name: "Tussenvoegsel",
                table: "Klant");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Klant");

            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "Klant",
                newName: "Naam");

            migrationBuilder.AddColumn<int>(
                name: "KlantId",
                table: "Reservering",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_KlantId",
                table: "Reservering",
                column: "KlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservering_Klant_KlantId",
                table: "Reservering",
                column: "KlantId",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
