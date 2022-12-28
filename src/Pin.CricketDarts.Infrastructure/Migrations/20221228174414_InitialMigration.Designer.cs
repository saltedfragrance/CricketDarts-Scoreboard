﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pin.CricketDarts.Infrastructure.Data;

#nullable disable

namespace Pin.CricketDarts.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221228174414_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ActiveGame")
                        .HasColumnType("bit");

                    b.Property<Guid>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed06932d-ec42-4de5-83d7-395093100219"),
                            ActiveGame = false,
                            WinnerId = new Guid("8afe52ab-f3a4-4742-b4f7-67e54b2a2dc8")
                        },
                        new
                        {
                            Id = new Guid("82bfb14d-bcff-46d3-8dab-66498cf4d5bc"),
                            ActiveGame = false,
                            WinnerId = new Guid("f08854d9-e0ae-47a6-b7c9-8a14e9af194b")
                        },
                        new
                        {
                            Id = new Guid("5e066679-39e5-4bf8-a26b-b1f0e49a68df"),
                            ActiveGame = false,
                            WinnerId = new Guid("d6bc8afc-f051-4741-934d-a2a00443c201")
                        },
                        new
                        {
                            Id = new Guid("f97cc947-64b3-4989-a0b5-4429e86cfeda"),
                            ActiveGame = false,
                            WinnerId = new Guid("8354dbbb-6d2c-4a0f-aad9-64b4fdc27dfe")
                        },
                        new
                        {
                            Id = new Guid("5e6315c8-cce0-464b-b913-f74bfac8304f"),
                            ActiveGame = false,
                            WinnerId = new Guid("790c2820-f1d4-4298-994b-44d281481ad8")
                        },
                        new
                        {
                            Id = new Guid("02a34123-2c0a-44fd-bc0f-0b2811a0bf49"),
                            ActiveGame = false,
                            WinnerId = new Guid("d5075f8b-2790-4454-9fb3-214d617f6c01")
                        });
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.PersonalStatistics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DoublesThrown")
                        .HasColumnType("int");

                    b.Property<int>("GamesLost")
                        .HasColumnType("int");

                    b.Property<int>("GamesWon")
                        .HasColumnType("int");

                    b.Property<int>("TriplesThrown")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PlayerStatistics");

                    b.HasData(
                        new
                        {
                            Id = new Guid("59062baa-5af2-483d-a683-8f982252a3d9"),
                            DoublesThrown = 2,
                            GamesLost = 2,
                            GamesWon = 4,
                            TriplesThrown = 3
                        },
                        new
                        {
                            Id = new Guid("fcf8914b-061f-4e1c-af01-9fbb8f0847e9"),
                            DoublesThrown = 53,
                            GamesLost = 6,
                            GamesWon = 22,
                            TriplesThrown = 22
                        },
                        new
                        {
                            Id = new Guid("0928ac0b-b2f6-4189-9280-2318c8ab91d2"),
                            DoublesThrown = 52,
                            GamesLost = 34,
                            GamesWon = 6,
                            TriplesThrown = 45
                        },
                        new
                        {
                            Id = new Guid("fd89d57c-01ea-4938-9061-4961c3ed02dc"),
                            DoublesThrown = 53,
                            GamesLost = 56,
                            GamesWon = 4,
                            TriplesThrown = 7
                        },
                        new
                        {
                            Id = new Guid("1389d5cd-2fa1-4dfd-a422-c4e30e89686e"),
                            DoublesThrown = 22,
                            GamesLost = 25,
                            GamesWon = 77,
                            TriplesThrown = 6
                        },
                        new
                        {
                            Id = new Guid("f49ac80b-e798-4ae6-8689-2016921e6a64"),
                            DoublesThrown = 33,
                            GamesLost = 12,
                            GamesWon = 4,
                            TriplesThrown = 33
                        });
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonalStatisticsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PersonalStatisticsId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8afe52ab-f3a4-4742-b4f7-67e54b2a2dc8"),
                            Name = "VincentVega",
                            PersonalStatisticsId = new Guid("59062baa-5af2-483d-a683-8f982252a3d9")
                        },
                        new
                        {
                            Id = new Guid("f08854d9-e0ae-47a6-b7c9-8a14e9af194b"),
                            Name = "BruceWillis",
                            PersonalStatisticsId = new Guid("fcf8914b-061f-4e1c-af01-9fbb8f0847e9")
                        },
                        new
                        {
                            Id = new Guid("d6bc8afc-f051-4741-934d-a2a00443c201"),
                            Name = "Fabienne",
                            PersonalStatisticsId = new Guid("0928ac0b-b2f6-4189-9280-2318c8ab91d2")
                        },
                        new
                        {
                            Id = new Guid("8354dbbb-6d2c-4a0f-aad9-64b4fdc27dfe"),
                            Name = "Butch",
                            PersonalStatisticsId = new Guid("fd89d57c-01ea-4938-9061-4961c3ed02dc")
                        },
                        new
                        {
                            Id = new Guid("790c2820-f1d4-4298-994b-44d281481ad8"),
                            Name = "JohnTravolta",
                            PersonalStatisticsId = new Guid("1389d5cd-2fa1-4dfd-a422-c4e30e89686e")
                        },
                        new
                        {
                            Id = new Guid("d5075f8b-2790-4454-9fb3-214d617f6c01"),
                            Name = "TheWolf",
                            PersonalStatisticsId = new Guid("f49ac80b-e798-4ae6-8689-2016921e6a64")
                        });
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.PlayerGames", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GameId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerGames");

                    b.HasData(
                        new
                        {
                            GameId = new Guid("ed06932d-ec42-4de5-83d7-395093100219"),
                            PlayerId = new Guid("8afe52ab-f3a4-4742-b4f7-67e54b2a2dc8")
                        },
                        new
                        {
                            GameId = new Guid("ed06932d-ec42-4de5-83d7-395093100219"),
                            PlayerId = new Guid("f08854d9-e0ae-47a6-b7c9-8a14e9af194b")
                        },
                        new
                        {
                            GameId = new Guid("82bfb14d-bcff-46d3-8dab-66498cf4d5bc"),
                            PlayerId = new Guid("d6bc8afc-f051-4741-934d-a2a00443c201")
                        },
                        new
                        {
                            GameId = new Guid("82bfb14d-bcff-46d3-8dab-66498cf4d5bc"),
                            PlayerId = new Guid("8354dbbb-6d2c-4a0f-aad9-64b4fdc27dfe")
                        },
                        new
                        {
                            GameId = new Guid("5e066679-39e5-4bf8-a26b-b1f0e49a68df"),
                            PlayerId = new Guid("790c2820-f1d4-4298-994b-44d281481ad8")
                        },
                        new
                        {
                            GameId = new Guid("5e066679-39e5-4bf8-a26b-b1f0e49a68df"),
                            PlayerId = new Guid("d5075f8b-2790-4454-9fb3-214d617f6c01")
                        });
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Score", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Score");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d42a98b-24b8-4e36-8886-b419ec12a998"),
                            GameId = new Guid("ed06932d-ec42-4de5-83d7-395093100219"),
                            PlayerId = new Guid("8afe52ab-f3a4-4742-b4f7-67e54b2a2dc8"),
                            TotalScore = 20
                        },
                        new
                        {
                            Id = new Guid("25441e34-b16e-447c-bbdd-a3c24df2aecf"),
                            GameId = new Guid("ed06932d-ec42-4de5-83d7-395093100219"),
                            PlayerId = new Guid("f08854d9-e0ae-47a6-b7c9-8a14e9af194b"),
                            TotalScore = 40
                        },
                        new
                        {
                            Id = new Guid("d3195e38-6b3b-4f6b-9667-86ea882a592e"),
                            GameId = new Guid("82bfb14d-bcff-46d3-8dab-66498cf4d5bc"),
                            PlayerId = new Guid("d6bc8afc-f051-4741-934d-a2a00443c201"),
                            TotalScore = 2
                        },
                        new
                        {
                            Id = new Guid("91a663b7-7dee-4709-98c6-bedbd1b22241"),
                            GameId = new Guid("82bfb14d-bcff-46d3-8dab-66498cf4d5bc"),
                            PlayerId = new Guid("8354dbbb-6d2c-4a0f-aad9-64b4fdc27dfe"),
                            TotalScore = 33
                        },
                        new
                        {
                            Id = new Guid("72b81fae-1b16-4d18-bd1c-d6d07df277b3"),
                            GameId = new Guid("5e066679-39e5-4bf8-a26b-b1f0e49a68df"),
                            PlayerId = new Guid("790c2820-f1d4-4298-994b-44d281481ad8"),
                            TotalScore = 54
                        },
                        new
                        {
                            Id = new Guid("1f0124ee-3923-4a07-806e-7c450fa06803"),
                            GameId = new Guid("5e066679-39e5-4bf8-a26b-b1f0e49a68df"),
                            PlayerId = new Guid("d5075f8b-2790-4454-9fb3-214d617f6c01"),
                            TotalScore = 4
                        });
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Player", b =>
                {
                    b.HasOne("Pin.CricketDarts.Core.Entities.PersonalStatistics", "PersonalStatistics")
                        .WithMany()
                        .HasForeignKey("PersonalStatisticsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalStatistics");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.PlayerGames", b =>
                {
                    b.HasOne("Pin.CricketDarts.Core.Entities.Game", "Game")
                        .WithMany("PlayerGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pin.CricketDarts.Core.Entities.Player", "Player")
                        .WithMany("PlayerGames")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Score", b =>
                {
                    b.HasOne("Pin.CricketDarts.Core.Entities.Game", null)
                        .WithMany("Scores")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pin.CricketDarts.Core.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Game", b =>
                {
                    b.Navigation("PlayerGames");

                    b.Navigation("Scores");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Player", b =>
                {
                    b.Navigation("PlayerGames");
                });
#pragma warning restore 612, 618
        }
    }
}