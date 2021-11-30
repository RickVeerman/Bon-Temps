using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bon_temps.Data.Migrations
{
    public partial class initieel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Preposition",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Allergie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Allergeen = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrankSoort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soort = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrankSoort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GerechtSoort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soort = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GerechtSoort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Woonplaats = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klant_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuSoort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soort = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSoort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vegetarisch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soort = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vegetarisch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrankSoortId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Prijs = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drank_DrankSoort_DrankSoortId",
                        column: x => x.DrankSoortId,
                        principalTable: "DrankSoort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gerecht",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GerechtSoortId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerecht", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gerecht_GerechtSoort_GerechtSoortId",
                        column: x => x.GerechtSoortId,
                        principalTable: "GerechtSoort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tijd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservering_Klant_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuSoortId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_MenuSoort_MenuSoortId",
                        column: x => x.MenuSoortId,
                        principalTable: "MenuSoort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Eenheid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VegetarischId = table.Column<int>(type: "int", nullable: false),
                    AllergieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_Allergie_AllergieId",
                        column: x => x.AllergieId,
                        principalTable: "Allergie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredient_Vegetarisch_VegetarischId",
                        column: x => x.VegetarischId,
                        principalTable: "Vegetarisch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BestelRegel",
                columns: table => new
                {
                    ReserveringId = table.Column<int>(type: "int", nullable: false),
                    DrankId = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestelRegel", x => new { x.DrankId, x.ReserveringId });
                    table.ForeignKey(
                        name: "FK_BestelRegel_Drank_DrankId",
                        column: x => x.DrankId,
                        principalTable: "Drank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BestelRegel_Reservering_ReserveringId",
                        column: x => x.ReserveringId,
                        principalTable: "Reservering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReserveringMenu",
                columns: table => new
                {
                    ReserveringId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveringMenu", x => new { x.ReserveringId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_ReserveringMenu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveringMenu_Reservering_ReserveringId",
                        column: x => x.ReserveringId,
                        principalTable: "Reservering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GerechtIngredient",
                columns: table => new
                {
                    GerechtId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GerechtIngredient", x => new { x.GerechtId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_GerechtIngredient_Gerecht_GerechtId",
                        column: x => x.GerechtId,
                        principalTable: "Gerecht",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GerechtIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergie",
                columns: new[] { "Id", "Allergeen" },
                values: new object[,]
                {
                    { 1, "Geen" },
                    { 2, "Koemelk" },
                    { 3, "Kippenei" },
                    { 4, "Pinda" },
                    { 5, "Noten" },
                    { 6, "Vis, schaal- en schelpdieren" },
                    { 7, "Roosfruit" },
                    { 8, "Soja" },
                    { 9, "TSarwe" }
                });

            migrationBuilder.InsertData(
                table: "GerechtSoort",
                columns: new[] { "Id", "Soort" },
                values: new object[,]
                {
                    { 3, "Nagerecht" },
                    { 1, "Voorgerecht" },
                    { 2, "Hoofdgerecht" }
                });

            migrationBuilder.InsertData(
                table: "MenuSoort",
                columns: new[] { "Id", "Soort" },
                values: new object[,]
                {
                    { 1, "Lunch" },
                    { 2, "Diner" }
                });

            migrationBuilder.InsertData(
                table: "Vegetarisch",
                columns: new[] { "Id", "Soort" },
                values: new object[,]
                {
                    { 5, "Lacto-Ovo vegetarisch" },
                    { 1, "Niet vegetarisch" },
                    { 2, "Veganistisch" },
                    { 3, "Lacto-vegetarisch" },
                    { 4, "Ovo-vegetarisch" },
                    { 6, "Pescatarian" }
                });

            migrationBuilder.InsertData(
                table: "Gerecht",
                columns: new[] { "Id", "GerechtSoortId", "Naam" },
                values: new object[,]
                {
                    { 1, 1, "UienSoep" },
                    { 2, 1, "Groentesoep" },
                    { 3, 1, "Carpaccio" },
                    { 4, 1, "Noorse Garnalenpasta" },
                    { 5, 2, "Rösti met Avocado" },
                    { 6, 3, "Dame Blanche" }
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "AllergieId", "Eenheid", "Naam", "VegetarischId" },
                values: new object[,]
                {
                    { 1, 1, "Zak 400 gram", "Soepgroente", 1 },
                    { 2, 1, "Stuk", "Ei", 1 },
                    { 3, 1, "Stuk", "Ui", 1 },
                    { 4, 1, "Blokje", "Bouillon", 1 },
                    { 5, 1, "mL", "Water", 1 },
                    { 6, 1, "Struik 400 gram", "Boerenkool", 1 }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "MenuSoortId", "Naam", "Prijs" },
                values: new object[] { 1, 2, "Feestmenu", 20m });

            migrationBuilder.CreateIndex(
                name: "IX_Allergie_Allergeen",
                table: "Allergie",
                column: "Allergeen",
                unique: true,
                filter: "[Allergeen] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BestelRegel_ReserveringId",
                table: "BestelRegel",
                column: "ReserveringId");

            migrationBuilder.CreateIndex(
                name: "IX_Drank_DrankSoortId",
                table: "Drank",
                column: "DrankSoortId");

            migrationBuilder.CreateIndex(
                name: "IX_Drank_Naam",
                table: "Drank",
                column: "Naam",
                unique: true,
                filter: "[Naam] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Gerecht_GerechtSoortId",
                table: "Gerecht",
                column: "GerechtSoortId");

            migrationBuilder.CreateIndex(
                name: "IX_Gerecht_Naam",
                table: "Gerecht",
                column: "Naam",
                unique: true,
                filter: "[Naam] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GerechtIngredient_IngredientId",
                table: "GerechtIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_GerechtSoort_Soort",
                table: "GerechtSoort",
                column: "Soort",
                unique: true,
                filter: "[Soort] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_AllergieId",
                table: "Ingredient",
                column: "AllergieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_Naam",
                table: "Ingredient",
                column: "Naam",
                unique: true,
                filter: "[Naam] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_VegetarischId",
                table: "Ingredient",
                column: "VegetarischId");

            migrationBuilder.CreateIndex(
                name: "IX_Klant_UserId",
                table: "Klant",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuSoortId",
                table: "Menu",
                column: "MenuSoortId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Naam",
                table: "Menu",
                column: "Naam",
                unique: true,
                filter: "[Naam] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSoort_Soort",
                table: "MenuSoort",
                column: "Soort",
                unique: true,
                filter: "[Soort] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_KlantId",
                table: "Reservering",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveringMenu_MenuId",
                table: "ReserveringMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Vegetarisch_Soort",
                table: "Vegetarisch",
                column: "Soort",
                unique: true,
                filter: "[Soort] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestelRegel");

            migrationBuilder.DropTable(
                name: "GerechtIngredient");

            migrationBuilder.DropTable(
                name: "ReserveringMenu");

            migrationBuilder.DropTable(
                name: "Drank");

            migrationBuilder.DropTable(
                name: "Gerecht");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Reservering");

            migrationBuilder.DropTable(
                name: "DrankSoort");

            migrationBuilder.DropTable(
                name: "GerechtSoort");

            migrationBuilder.DropTable(
                name: "Allergie");

            migrationBuilder.DropTable(
                name: "Vegetarisch");

            migrationBuilder.DropTable(
                name: "MenuSoort");

            migrationBuilder.DropTable(
                name: "Klant");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Preposition",
                table: "AspNetUsers");
        }
    }
}
