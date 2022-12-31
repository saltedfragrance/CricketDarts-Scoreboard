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
                    CurrentTurnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Status = table.Column<int>(type: "int", nullable: false)
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
                    { new Guid("15baa86c-a666-4e53-a4bb-d05e86e487e6"), 0, false, "Fabienne", 0, 0 },
                    { new Guid("34e7b3bc-8c34-4654-90ca-4db4fac882f8"), 0, false, "VincentVega", 0, 0 },
                    { new Guid("7342bfea-01ed-4f96-b26b-c5eee5898730"), 0, false, "BruceWillis", 0, 0 },
                    { new Guid("ac52bd0f-c648-4ff6-9dff-fb140f86b34d"), 0, false, "JohnTravolta", 0, 0 },
                    { new Guid("ae710b0f-3ffc-4dff-8d3f-d24b8853097a"), 0, false, "TheWolf", 0, 0 },
                    { new Guid("ddb00b6a-5523-45e9-8958-03533660e95c"), 0, false, "Butch", 0, 0 }
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
                    { new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), 0, new Guid("7342bfea-01ed-4f96-b26b-c5eee5898730"), 0 },
                    { new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59"), 3, new Guid("34e7b3bc-8c34-4654-90ca-4db4fac882f8"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CurrentTurnId", "IsActive", "TournamentId", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("4c69d921-bc5e-432d-9d93-b08bdacd5d9c"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("15baa86c-a666-4e53-a4bb-d05e86e487e6") },
                    { new Guid("61906e7b-99aa-4831-8eae-cc47593f6d15"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("ac52bd0f-c648-4ff6-9dff-fb140f86b34d") },
                    { new Guid("77c63634-324d-4450-a266-f94e8ac8332e"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("ddb00b6a-5523-45e9-8958-03533660e95c") },
                    { new Guid("8ba153a0-bad6-4abe-8bd3-f11a8e11f61a"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("34e7b3bc-8c34-4654-90ca-4db4fac882f8") },
                    { new Guid("c20eccc3-3c59-4767-98da-b4880fef97c8"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("7342bfea-01ed-4f96-b26b-c5eee5898730") },
                    { new Guid("e5382e8c-310e-490c-bd9b-47c07da33dd8"), new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), true, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("e5382e8c-310e-490c-bd9b-47c07da33dd8"), new Guid("34e7b3bc-8c34-4654-90ca-4db4fac882f8") },
                    { new Guid("e5382e8c-310e-490c-bd9b-47c07da33dd8"), new Guid("7342bfea-01ed-4f96-b26b-c5eee5898730") }
                });

            migrationBuilder.InsertData(
                table: "ScoreBoardEntries",
                columns: new[] { "Id", "GameId", "PlayerId", "Status", "Target", "TurnId" },
                values: new object[,]
                {
                    { new Guid("126b54da-7e80-486e-ab37-aac0ab237911"), new Guid("e5382e8c-310e-490c-bd9b-47c07da33dd8"), new Guid("34e7b3bc-8c34-4654-90ca-4db4fac882f8"), 2, 17, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("3f73190c-f565-451c-81ad-9d90c716cfe3"), new Guid("e5382e8c-310e-490c-bd9b-47c07da33dd8"), new Guid("34e7b3bc-8c34-4654-90ca-4db4fac882f8"), 3, 16, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("dcf56a0d-6bc7-421c-a85e-9f7df5d0fe17"), new Guid("e5382e8c-310e-490c-bd9b-47c07da33dd8"), new Guid("34e7b3bc-8c34-4654-90ca-4db4fac882f8"), 1, 15, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") }
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
