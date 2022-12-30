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
                    HasTurn = table.Column<bool>(type: "bit", nullable: false),
                    CurrentAmountOfThrows = table.Column<int>(type: "int", nullable: false),
                    CurrentTotalScore = table.Column<int>(type: "int", nullable: false),
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
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CurrentAmountOfThrows", "CurrentTotalScore", "Doubles", "HasTurn", "Name", "Triples" },
                values: new object[,]
                {
                    { new Guid("279d330d-b4ed-4a8d-876a-09ed8e708cef"), 0, 0, 0, false, "Fabienne", 0 },
                    { new Guid("2f5ae907-4d60-4eaf-9140-55e22759c124"), 0, 0, 0, false, "Butch", 0 },
                    { new Guid("446a8e92-ca2a-4721-b8ec-d3ab4dd1b516"), 0, 0, 0, false, "JohnTravolta", 0 },
                    { new Guid("642ba299-2a35-479f-b6df-3e3f893820cb"), 0, 0, 0, false, "BruceWillis", 0 },
                    { new Guid("91e4d9c4-ceb6-4259-ace1-9b24f57c704d"), 0, 0, 0, false, "VincentVega", 0 },
                    { new Guid("d74a7203-626b-4e84-9366-b0f4812b3925"), 0, 0, 0, false, "TheWolf", 0 }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "IsOngoing" },
                values: new object[] { new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), false });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsActive", "TournamentId", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("1aed4333-70c5-42e3-9e4c-dfa15e09a52f"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("642ba299-2a35-479f-b6df-3e3f893820cb") },
                    { new Guid("1b706538-3251-4494-b690-ccfbb1fae3b6"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("279d330d-b4ed-4a8d-876a-09ed8e708cef") },
                    { new Guid("22b1c4ae-e451-4b63-9c5b-7885d83ae516"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("446a8e92-ca2a-4721-b8ec-d3ab4dd1b516") },
                    { new Guid("4d1c0da4-2df9-4d08-b6f9-0ce74b225545"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("91e4d9c4-ceb6-4259-ace1-9b24f57c704d") },
                    { new Guid("71c86e97-54a8-454d-a448-ff5727be2568"), true, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("da70b0a1-d0e8-45df-9af0-2fe0fdcc45dc"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("2f5ae907-4d60-4eaf-9140-55e22759c124") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("71c86e97-54a8-454d-a448-ff5727be2568"), new Guid("642ba299-2a35-479f-b6df-3e3f893820cb") },
                    { new Guid("71c86e97-54a8-454d-a448-ff5727be2568"), new Guid("91e4d9c4-ceb6-4259-ace1-9b24f57c704d") }
                });

            migrationBuilder.InsertData(
                table: "ScoreBoardEntries",
                columns: new[] { "Id", "GameId", "PlayerId", "Status", "Target" },
                values: new object[,]
                {
                    { new Guid("0b11e093-7d4e-4539-97bc-598538e485d2"), new Guid("71c86e97-54a8-454d-a448-ff5727be2568"), new Guid("91e4d9c4-ceb6-4259-ace1-9b24f57c704d"), 3, 16 },
                    { new Guid("4744ca4a-eafa-43f3-ad7b-06b6ff02b6f0"), new Guid("71c86e97-54a8-454d-a448-ff5727be2568"), new Guid("642ba299-2a35-479f-b6df-3e3f893820cb"), 2, 17 },
                    { new Guid("48aa24cd-f770-4dbd-a0d7-6bc5df1795a9"), new Guid("71c86e97-54a8-454d-a448-ff5727be2568"), new Guid("91e4d9c4-ceb6-4259-ace1-9b24f57c704d"), 1, 15 }
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
                name: "Tournaments");
        }
    }
}
