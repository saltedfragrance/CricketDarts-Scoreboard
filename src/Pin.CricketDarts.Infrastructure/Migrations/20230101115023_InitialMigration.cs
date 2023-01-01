using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.CricketDarts.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPointsScored = table.Column<int>(type: "int", nullable: false),
                    HasTurn = table.Column<bool>(type: "bit", nullable: false),
                    Doubles = table.Column<int>(type: "int", nullable: false),
                    Triples = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOngoing = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentAmountOfThrows = table.Column<int>(type: "int", nullable: false),
                    PointsScored = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentTurnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.GameId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_PlayerGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreBoardEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreBoardEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoreBoardEntries_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreBoardEntries_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreBoardEntries_Turns_TurnId",
                        column: x => x.TurnId,
                        principalTable: "Turns",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Doubles", "HasTurn", "Name", "TotalPointsScored", "Triples" },
                values: new object[,]
                {
                    { new Guid("10df819b-0c35-4fc8-b006-6af0b25daf28"), 0, false, "JohnTravolta", 0, 0 },
                    { new Guid("4e13cef7-73c6-4cd0-944c-1ab5865e8358"), 0, false, "BruceWillis", 0, 0 },
                    { new Guid("50f82646-0285-4f74-b952-7adabce36c16"), 0, false, "TheWolf", 0, 0 },
                    { new Guid("c6116561-451e-4aa6-8376-4013e8521a2d"), 0, false, "Butch", 0, 0 },
                    { new Guid("d9077c70-af22-4ab6-a788-6ad4067dd07a"), 0, false, "VincentVega", 0, 0 },
                    { new Guid("e39c5d9e-3d00-4685-9805-0325ba0e10ef"), 0, false, "Fabienne", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "IsOngoing" },
                values: new object[] { new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), false });

            migrationBuilder.InsertData(
                table: "Turns",
                columns: new[] { "Id", "CurrentAmountOfThrows", "PlayerId", "PointsScored" },
                values: new object[,]
                {
                    { new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), 0, new Guid("4e13cef7-73c6-4cd0-944c-1ab5865e8358"), 0 },
                    { new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59"), 3, new Guid("d9077c70-af22-4ab6-a788-6ad4067dd07a"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CurrentTurnId", "IsActive", "TournamentId", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("2516a21c-0813-410b-814b-8ccf5d6fd58b"), new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), true, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("27ca0b5d-738d-43c0-8056-b686b5ebf8c3"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("c6116561-451e-4aa6-8376-4013e8521a2d") },
                    { new Guid("7faefea5-d263-45af-a0ab-dfc379fa386b"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("d9077c70-af22-4ab6-a788-6ad4067dd07a") },
                    { new Guid("c8c6c8ef-be6e-4d88-9980-3a286996d677"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("e39c5d9e-3d00-4685-9805-0325ba0e10ef") },
                    { new Guid("e3b6fa53-4b51-4ea6-8e02-06d502ec28cb"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("4e13cef7-73c6-4cd0-944c-1ab5865e8358") },
                    { new Guid("f6a5ea06-7022-4ebb-ad76-e679a9a7107c"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("10df819b-0c35-4fc8-b006-6af0b25daf28") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("2516a21c-0813-410b-814b-8ccf5d6fd58b"), new Guid("4e13cef7-73c6-4cd0-944c-1ab5865e8358") },
                    { new Guid("2516a21c-0813-410b-814b-8ccf5d6fd58b"), new Guid("d9077c70-af22-4ab6-a788-6ad4067dd07a") }
                });

            migrationBuilder.InsertData(
                table: "ScoreBoardEntries",
                columns: new[] { "Id", "GameId", "PlayerId", "Score", "Status", "Target", "TurnId" },
                values: new object[,]
                {
                    { new Guid("0daec266-6389-444c-8313-382edb2113dc"), new Guid("2516a21c-0813-410b-814b-8ccf5d6fd58b"), new Guid("d9077c70-af22-4ab6-a788-6ad4067dd07a"), 0, 1, 15, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("20e0e962-a298-4e26-84a9-9c313dc08cad"), new Guid("2516a21c-0813-410b-814b-8ccf5d6fd58b"), new Guid("d9077c70-af22-4ab6-a788-6ad4067dd07a"), 0, 2, 17, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("41b1e8b1-1a58-4a30-8ecc-9f296800d616"), new Guid("2516a21c-0813-410b-814b-8ccf5d6fd58b"), new Guid("d9077c70-af22-4ab6-a788-6ad4067dd07a"), 0, 3, 16, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_TournamentId",
                table: "Games",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_PlayerId",
                table: "PlayerGames",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoardEntries_GameId",
                table: "ScoreBoardEntries",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoardEntries_PlayerId",
                table: "ScoreBoardEntries",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoardEntries_TurnId",
                table: "ScoreBoardEntries",
                column: "TurnId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "ScoreBoardEntries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
