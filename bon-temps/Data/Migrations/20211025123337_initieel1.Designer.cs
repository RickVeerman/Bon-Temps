﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bon_temps.Data;

namespace bon_temps.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211025123337_initieel1")]
    partial class initieel1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("bon_temps.Models.Allergie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Allergeen")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Allergeen")
                        .IsUnique()
                        .HasFilter("[Allergeen] IS NOT NULL");

                    b.ToTable("Allergie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Allergeen = "Geen"
                        },
                        new
                        {
                            Id = 2,
                            Allergeen = "Koemelk"
                        },
                        new
                        {
                            Id = 3,
                            Allergeen = "Kippenei"
                        },
                        new
                        {
                            Id = 4,
                            Allergeen = "Pinda"
                        },
                        new
                        {
                            Id = 5,
                            Allergeen = "Noten"
                        },
                        new
                        {
                            Id = 6,
                            Allergeen = "Vis, schaal- en schelpdieren"
                        },
                        new
                        {
                            Id = 7,
                            Allergeen = "Roosfruit"
                        },
                        new
                        {
                            Id = 8,
                            Allergeen = "Soja"
                        },
                        new
                        {
                            Id = 9,
                            Allergeen = "TSarwe"
                        });
                });

            modelBuilder.Entity("bon_temps.Models.BestelRegel", b =>
                {
                    b.Property<int>("DrankId")
                        .HasColumnType("int");

                    b.Property<int>("ReserveringId")
                        .HasColumnType("int");

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.HasKey("DrankId", "ReserveringId");

                    b.HasIndex("ReserveringId");

                    b.ToTable("BestelRegel");
                });

            modelBuilder.Entity("bon_temps.Models.Drank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrankSoortId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Prijs")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DrankSoortId");

                    b.HasIndex("Naam")
                        .IsUnique()
                        .HasFilter("[Naam] IS NOT NULL");

                    b.ToTable("Drank");
                });

            modelBuilder.Entity("bon_temps.Models.DrankSoort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Soort")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DrankSoort");
                });

            modelBuilder.Entity("bon_temps.Models.Gerecht", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GerechtSoortId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GerechtSoortId");

                    b.HasIndex("Naam")
                        .IsUnique()
                        .HasFilter("[Naam] IS NOT NULL");

                    b.ToTable("Gerecht");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GerechtSoortId = 1,
                            Naam = "UienSoep"
                        },
                        new
                        {
                            Id = 2,
                            GerechtSoortId = 1,
                            Naam = "Groentesoep"
                        },
                        new
                        {
                            Id = 3,
                            GerechtSoortId = 1,
                            Naam = "Carpaccio"
                        },
                        new
                        {
                            Id = 4,
                            GerechtSoortId = 1,
                            Naam = "Noorse Garnalenpasta"
                        },
                        new
                        {
                            Id = 5,
                            GerechtSoortId = 2,
                            Naam = "Rösti met Avocado"
                        },
                        new
                        {
                            Id = 6,
                            GerechtSoortId = 3,
                            Naam = "Dame Blanche"
                        });
                });

            modelBuilder.Entity("bon_temps.Models.GerechtIngredient", b =>
                {
                    b.Property<int>("GerechtId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.HasKey("GerechtId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("GerechtIngredient");
                });

            modelBuilder.Entity("bon_temps.Models.GerechtSoort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Soort")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Soort")
                        .IsUnique()
                        .HasFilter("[Soort] IS NOT NULL");

                    b.ToTable("GerechtSoort");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Soort = "Voorgerecht"
                        },
                        new
                        {
                            Id = 2,
                            Soort = "Hoofdgerecht"
                        },
                        new
                        {
                            Id = 3,
                            Soort = "Nagerecht"
                        });
                });

            modelBuilder.Entity("bon_temps.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AllergieId")
                        .HasColumnType("int");

                    b.Property<string>("Eenheid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("VegetarischId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AllergieId");

                    b.HasIndex("Naam")
                        .IsUnique()
                        .HasFilter("[Naam] IS NOT NULL");

                    b.HasIndex("VegetarischId");

                    b.ToTable("Ingredient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AllergieId = 1,
                            Eenheid = "Zak 400 gram",
                            Naam = "Soepgroente",
                            VegetarischId = 1
                        },
                        new
                        {
                            Id = 2,
                            AllergieId = 1,
                            Eenheid = "Stuk",
                            Naam = "Ei",
                            VegetarischId = 1
                        },
                        new
                        {
                            Id = 3,
                            AllergieId = 1,
                            Eenheid = "Stuk",
                            Naam = "Ui",
                            VegetarischId = 1
                        },
                        new
                        {
                            Id = 4,
                            AllergieId = 1,
                            Eenheid = "Blokje",
                            Naam = "Bouillon",
                            VegetarischId = 1
                        },
                        new
                        {
                            Id = 5,
                            AllergieId = 1,
                            Eenheid = "mL",
                            Naam = "Water",
                            VegetarischId = 1
                        },
                        new
                        {
                            Id = 6,
                            AllergieId = 1,
                            Eenheid = "Struik 400 gram",
                            Naam = "Boerenkool",
                            VegetarischId = 1
                        });
                });

            modelBuilder.Entity("bon_temps.Models.Klant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Woonplaats")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Klant");
                });

            modelBuilder.Entity("bon_temps.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuSoortId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MenuSoortId");

                    b.HasIndex("Naam")
                        .IsUnique()
                        .HasFilter("[Naam] IS NOT NULL");

                    b.ToTable("Menu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuSoortId = 2,
                            Naam = "Feestmenu",
                            Prijs = 20m
                        });
                });

            modelBuilder.Entity("bon_temps.Models.MenuSoort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Soort")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Soort")
                        .IsUnique()
                        .HasFilter("[Soort] IS NOT NULL");

                    b.ToTable("MenuSoort");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Soort = "Lunch"
                        },
                        new
                        {
                            Id = 2,
                            Soort = "Diner"
                        });
                });

            modelBuilder.Entity("bon_temps.Models.Reservering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KlantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tijd")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KlantId");

                    b.ToTable("Reservering");
                });

            modelBuilder.Entity("bon_temps.Models.ReserveringMenu", b =>
                {
                    b.Property<int>("ReserveringId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.HasKey("ReserveringId", "MenuId");

                    b.HasIndex("MenuId");

                    b.ToTable("ReserveringMenu");
                });

            modelBuilder.Entity("bon_temps.Models.Vegetarisch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Soort")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Soort")
                        .IsUnique()
                        .HasFilter("[Soort] IS NOT NULL");

                    b.ToTable("Vegetarisch");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Soort = "Niet vegetarisch"
                        },
                        new
                        {
                            Id = 2,
                            Soort = "Veganistisch"
                        },
                        new
                        {
                            Id = 3,
                            Soort = "Lacto-vegetarisch"
                        },
                        new
                        {
                            Id = 4,
                            Soort = "Ovo-vegetarisch"
                        },
                        new
                        {
                            Id = 5,
                            Soort = "Lacto-Ovo vegetarisch"
                        },
                        new
                        {
                            Id = 6,
                            Soort = "Pescatarian"
                        });
                });

            modelBuilder.Entity("bon_temps.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Preposition")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bon_temps.Models.BestelRegel", b =>
                {
                    b.HasOne("bon_temps.Models.Drank", "Drank")
                        .WithMany()
                        .HasForeignKey("DrankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bon_temps.Models.Reservering", "Reservering")
                        .WithMany()
                        .HasForeignKey("ReserveringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drank");

                    b.Navigation("Reservering");
                });

            modelBuilder.Entity("bon_temps.Models.Drank", b =>
                {
                    b.HasOne("bon_temps.Models.DrankSoort", "DrankSoort")
                        .WithMany()
                        .HasForeignKey("DrankSoortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrankSoort");
                });

            modelBuilder.Entity("bon_temps.Models.Gerecht", b =>
                {
                    b.HasOne("bon_temps.Models.GerechtSoort", "GerechtSoort")
                        .WithMany()
                        .HasForeignKey("GerechtSoortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GerechtSoort");
                });

            modelBuilder.Entity("bon_temps.Models.GerechtIngredient", b =>
                {
                    b.HasOne("bon_temps.Models.Gerecht", "Gerecht")
                        .WithMany()
                        .HasForeignKey("GerechtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bon_temps.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gerecht");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("bon_temps.Models.Ingredient", b =>
                {
                    b.HasOne("bon_temps.Models.Allergie", "Allergie")
                        .WithMany()
                        .HasForeignKey("AllergieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bon_temps.Models.Vegetarisch", "Vegetarisch")
                        .WithMany()
                        .HasForeignKey("VegetarischId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergie");

                    b.Navigation("Vegetarisch");
                });

            modelBuilder.Entity("bon_temps.Models.Klant", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("bon_temps.Models.Menu", b =>
                {
                    b.HasOne("bon_temps.Models.MenuSoort", "MenuSoort")
                        .WithMany()
                        .HasForeignKey("MenuSoortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuSoort");
                });

            modelBuilder.Entity("bon_temps.Models.Reservering", b =>
                {
                    b.HasOne("bon_temps.Models.Klant", "Klant")
                        .WithMany()
                        .HasForeignKey("KlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klant");
                });

            modelBuilder.Entity("bon_temps.Models.ReserveringMenu", b =>
                {
                    b.HasOne("bon_temps.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bon_temps.Models.Reservering", "Reservering")
                        .WithMany()
                        .HasForeignKey("ReserveringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Reservering");
                });
#pragma warning restore 612, 618
        }
    }
}
