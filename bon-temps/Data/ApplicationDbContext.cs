using bon_temps.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace bon_temps.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Klant>()
                .HasIndex(k => k.UserId)
                .IsUnique();

            builder.Entity<GerechtIngredient>()
               .HasKey(table => new
               {
                   table.GerechtId,
                   table.IngredientId
               });

            builder.Entity<ReserveringMenu>()
               .HasKey(table => new
               {
                   table.ReserveringId,
                   table.MenuId
               });

            builder.Entity<BestelRegel>()
               .HasKey(table => new
               {
                   table.DrankId,
                   table.ReserveringId
               });

            builder.Entity<Gerecht>()
                .HasIndex(g => g.Naam)
                .IsUnique();

            builder.Entity<GerechtSoort>()
                .HasIndex(g => g.Soort)
                .IsUnique();

            builder.Entity<Ingredient>()
                .HasIndex(i => i.Naam)
                .IsUnique();

            builder.Entity<Vegetarisch>()
                .HasIndex(v => v.Soort)
                .IsUnique();

            builder.Entity<Allergie>()
                .HasIndex(a => a.Allergeen)
                .IsUnique();

            builder.Entity<Menu>()
                .HasIndex(m => m.Naam)
                .IsUnique();

            builder.Entity<MenuSoort>()
                .HasIndex(m => m.Soort)
                .IsUnique();

            builder.Entity<Drank>()
                .HasIndex(d => d.Naam)
                .IsUnique();

            builder.Entity<Vegetarisch>().HasData(
               new Vegetarisch { Id = 1, Soort = "Niet vegetarisch" },
               new Vegetarisch { Id = 2, Soort = "Veganistisch" },
               new Vegetarisch { Id = 3, Soort = "Lacto-vegetarisch" },
               new Vegetarisch { Id = 4, Soort = "Ovo-vegetarisch" },
               new Vegetarisch { Id = 5, Soort = "Lacto-Ovo vegetarisch" },
               new Vegetarisch { Id = 6, Soort = "Pescatarian" }
           );

            builder.Entity<Allergie>().HasData(
                new Allergie { Id = 1, Allergeen = "Geen" },
                new Allergie { Id = 2, Allergeen = "Koemelk" },
                new Allergie { Id = 3, Allergeen = "Kippenei" },
                new Allergie { Id = 4, Allergeen = "Pinda" },
                new Allergie { Id = 5, Allergeen = "Noten" },
                new Allergie { Id = 6, Allergeen = "Vis, schaal- en schelpdieren" },
                new Allergie { Id = 7, Allergeen = "Roosfruit" },
                new Allergie { Id = 8, Allergeen = "Soja" },
                new Allergie { Id = 9, Allergeen = "TSarwe" }
            );

            builder.Entity<GerechtSoort>().HasData(
                new GerechtSoort { Id = 1, Soort = "Voorgerecht" },
                new GerechtSoort { Id = 2, Soort = "Hoofdgerecht" },
                new GerechtSoort { Id = 3, Soort = "Nagerecht" }

            );

            builder.Entity<MenuSoort>().HasData(
                new MenuSoort { Id = 1, Soort = "Lunch" },
                new MenuSoort { Id = 2, Soort = "Diner" }

            );

            builder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Naam = "Soepgroente", Eenheid = "Zak 400 gram", VegetarischId = 1, AllergieId = 1},
                new Ingredient { Id = 2, Naam = "Ei", Eenheid = "Stuk", VegetarischId = 1, AllergieId = 1 },
                new Ingredient { Id = 3, Naam = "Ui", Eenheid = "Stuk", VegetarischId = 1, AllergieId = 1 },
                new Ingredient { Id = 4, Naam = "Bouillon", Eenheid = "Blokje", VegetarischId = 1, AllergieId = 1 },
                new Ingredient { Id = 5, Naam = "Water", Eenheid = "mL", VegetarischId = 1, AllergieId = 1 },
                new Ingredient { Id = 6, Naam = "Boerenkool", Eenheid = "Struik 400 gram", VegetarischId = 1, AllergieId = 1 }

            );

            builder.Entity<Gerecht>().HasData(
                new Gerecht { Id = 1, GerechtSoortId = 1, Naam = "Uiensoep" },
                new Gerecht { Id = 2, GerechtSoortId = 1, Naam = "Groentesoep" },
                new Gerecht { Id = 3, GerechtSoortId = 1, Naam = "Carpaccio" },
                new Gerecht { Id = 4, GerechtSoortId = 1, Naam = "Noorse Garnalenpasta" },
                new Gerecht { Id = 5, GerechtSoortId = 2, Naam = "Rösti met Avocado" },
                new Gerecht { Id = 6, GerechtSoortId = 3, Naam = "Dame Blanche" },
                new Gerecht { Id = 7, GerechtSoortId = 3, Naam = "Soft Ijs"}
         

            );

            builder.Entity<Menu>().HasData(
                new Menu { Id = 1, MenuSoortId = 2, Naam = "Feestmenu", Prijs = 20 },
                new Menu { Id = 2, MenuSoortId = 1, Naam = "Taartmenu", Prijs = 10 },
                new Menu { Id = 3, MenuSoortId = 2, Naam = "Seizoensmenu", Prijs = 23 },
                new Menu { Id = 4, MenuSoortId = 2, Naam = "Kerstmenu", Prijs = 28 }
            );

            builder.Entity<DrankSoort>().HasData(
                new DrankSoort { Id = 1, Soort = "Warme Dranken" },
                new DrankSoort { Id = 2, Soort = "Koude Dranken" },
                new DrankSoort { Id = 3, Soort = "Bieren" },
                new DrankSoort { Id = 4, Soort = "Wijnen" },
                new DrankSoort { Id = 5, Soort = "Sterke Dranken" },
                new DrankSoort { Id = 6, Soort = "Gemixte Dranken" }
            );

            builder.Entity<Drank>().HasData(
                new Drank { Id = 1, DrankSoortId = 3, Naam = "Heineken", Prijs = 2.80 },
                new Drank { Id = 2, DrankSoortId = 4, Naam = "Chardonnay", Prijs = 4.50 },
                new Drank { Id = 3, DrankSoortId = 2, Naam = "Colca Cola", Prijs = 2.20 },
                new Drank { Id = 4, DrankSoortId = 1, Naam = "Koffie", Prijs = 1.50 },
                new Drank { Id = 5, DrankSoortId = 5, Naam = "Campari", Prijs = 2.50 },
                new Drank { Id = 6, DrankSoortId = 6, Naam = "Bacardi Cola", Prijs = 6.00 }
            );


        }
        public DbSet<bon_temps.Models.Allergie> Allergie { get; set; }
        public DbSet<bon_temps.Models.Vegetarisch> Vegetarisch { get; set; }
        public DbSet<bon_temps.Models.Reservering> Reservering { get; set; }
        public DbSet<bon_temps.Models.Menu> Menu { get; set; }
        public DbSet<bon_temps.Models.Drank> Drank { get; set; }
        public DbSet<bon_temps.Models.Gerecht> Gerecht { get; set; }
        public DbSet<bon_temps.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<bon_temps.Models.GerechtSoort> GerechtSoort { get; set; }
        public DbSet<bon_temps.Models.MenuSoort> MenuSoort { get; set; }
        public DbSet<bon_temps.Models.DrankSoort> DrankSoort { get; set; }
        public DbSet<bon_temps.Models.GerechtIngredient> GerechtIngredient { get; set; }
        public DbSet<bon_temps.Models.Ingredient> Ingredient { get; set; }
        public DbSet<bon_temps.Models.ReserveringMenu> ReserveringMenu { get; set; }
    }
}
