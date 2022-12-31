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
                    TurnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Doubles", "HasTurn", "Name", "TotalPointsScored", "Triples" },
                values: new object[,]
                {
                    { new Guid("0948da66-68d7-4c84-b4ba-a5cf29485a69"), 0, false, "BruceWillis", 0, 0 },
                    { new Guid("216ff991-0c8f-488a-830b-3158e3185ee9"), 0, false, "Fabienne", 0, 0 },
                    { new Guid("2c5753ab-656c-47a3-89b0-08a90a087f5c"), 0, false, "TheWolf", 0, 0 },
                    { new Guid("86b5a624-8435-4ffb-9eba-2a5a95445e6e"), 0, false, "Butch", 0, 0 },
                    { new Guid("95adddc1-90c7-4f23-8627-79a405469ac4"), 0, false, "VincentVega", 0, 0 },
                    { new Guid("a3777259-7f5d-4e4b-807d-9896355a23e5"), 0, false, "JohnTravolta", 0, 0 }
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
                    { new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), 0, new Guid("0948da66-68d7-4c84-b4ba-a5cf29485a69"), 0 },
                    { new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59"), 3, new Guid("95adddc1-90c7-4f23-8627-79a405469ac4"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CurrentTurnId", "IsActive", "TournamentId", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("5966d61e-c2f8-47c3-9fd9-b8c086fd7dd2"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("86b5a624-8435-4ffb-9eba-2a5a95445e6e") },
                    { new Guid("604d7cda-53ff-44b7-b488-0a721cd08f12"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("0948da66-68d7-4c84-b4ba-a5cf29485a69") },
                    { new Guid("78eb258a-eff6-4613-b4de-56410071ffb9"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("95adddc1-90c7-4f23-8627-79a405469ac4") },
                    { new Guid("be450d01-a216-4bd1-be2c-7e07f1e8bfe9"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("a3777259-7f5d-4e4b-807d-9896355a23e5") },
                    { new Guid("d866da0b-8660-4d3b-aa7c-6401ee71028d"), new Guid("00000000-0000-0000-0000-000000000000"), true, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("efa3002a-7845-4d4d-875d-56ea63fc3916"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("216ff991-0c8f-488a-830b-3158e3185ee9") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("d866da0b-8660-4d3b-aa7c-6401ee71028d"), new Guid("0948da66-68d7-4c84-b4ba-a5cf29485a69") },
                    { new Guid("d866da0b-8660-4d3b-aa7c-6401ee71028d"), new Guid("95adddc1-90c7-4f23-8627-79a405469ac4") }
                });

            migrationBuilder.InsertData(
                table: "ScoreBoardEntries",
                columns: new[] { "Id", "GameId", "PlayerId", "Status", "Target", "TurnId" },
                values: new object[,]
                {
                    { new Guid("68f7110b-edf6-4b3e-b052-af9016243eef"), new Guid("d866da0b-8660-4d3b-aa7c-6401ee71028d"), new Guid("95adddc1-90c7-4f23-8627-79a405469ac4"), 2, 17, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("9efc7505-a3d6-4222-8ccc-83f7a43ef10d"), new Guid("d866da0b-8660-4d3b-aa7c-6401ee71028d"), new Guid("95adddc1-90c7-4f23-8627-79a405469ac4"), 3, 16, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("c0958e1e-a9e9-431d-a00f-5b74670c646c"), new Guid("d866da0b-8660-4d3b-aa7c-6401ee71028d"), new Guid("95adddc1-90c7-4f23-8627-79a405469ac4"), 1, 15, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") }
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
