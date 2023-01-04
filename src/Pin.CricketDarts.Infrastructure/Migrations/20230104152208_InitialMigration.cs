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
                    PointsScored = table.Column<int>(type: "int", nullable: false),
                    SelectionMode = table.Column<bool>(type: "bit", nullable: false)
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
                    Score = table.Column<int>(type: "int", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountClicks = table.Column<int>(type: "int", nullable: false)
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
                    { new Guid("0d7fc49d-61c4-41bd-ae39-e1551c5f4b89"), 0, false, "VincentVega", 0, 0 },
                    { new Guid("2f917c20-f91c-4f03-a2f0-1213de1d0d0e"), 0, false, "BruceWillis", 0, 0 },
                    { new Guid("2fb030b3-c674-4ce3-b7d9-55d581fa339a"), 0, false, "Butch", 0, 0 },
                    { new Guid("3a8dc0be-c019-446f-a6cc-a14ffe935aa0"), 0, false, "TheWolf", 0, 0 },
                    { new Guid("5746d387-48b7-4d34-b02c-9fd6e57d8cbc"), 0, false, "Fabienne", 0, 0 },
                    { new Guid("67f7b2bf-572c-4712-9421-15f74c421782"), 0, false, "JohnTravolta", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "IsOngoing" },
                values: new object[] { new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), false });

            migrationBuilder.InsertData(
                table: "Turns",
                columns: new[] { "Id", "CurrentAmountOfThrows", "PlayerId", "PointsScored", "SelectionMode" },
                values: new object[,]
                {
                    { new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), 0, new Guid("2f917c20-f91c-4f03-a2f0-1213de1d0d0e"), 0, false },
                    { new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59"), 3, new Guid("0d7fc49d-61c4-41bd-ae39-e1551c5f4b89"), 0, false }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CurrentTurnId", "IsActive", "TournamentId", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("1b5bf9f6-14a6-4608-9856-fe3d2e55ef58"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("2f917c20-f91c-4f03-a2f0-1213de1d0d0e") },
                    { new Guid("3fa1ae29-3aed-433e-88e7-7d6264d535bd"), new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), true, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9aa5355b-c511-45bd-83c4-5101b954317f"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("5746d387-48b7-4d34-b02c-9fd6e57d8cbc") },
                    { new Guid("adf77355-7b90-4e0a-8108-4eaf300f4f76"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("2fb030b3-c674-4ce3-b7d9-55d581fa339a") },
                    { new Guid("d6738a9a-0c38-41d9-ad47-2fed74b1e18e"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("67f7b2bf-572c-4712-9421-15f74c421782") },
                    { new Guid("e814ed81-9f91-4572-a799-d1bb283b836d"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("0d7fc49d-61c4-41bd-ae39-e1551c5f4b89") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("3fa1ae29-3aed-433e-88e7-7d6264d535bd"), new Guid("0d7fc49d-61c4-41bd-ae39-e1551c5f4b89") },
                    { new Guid("3fa1ae29-3aed-433e-88e7-7d6264d535bd"), new Guid("2f917c20-f91c-4f03-a2f0-1213de1d0d0e") }
                });

            migrationBuilder.InsertData(
                table: "ScoreBoardEntries",
                columns: new[] { "Id", "AmountClicks", "DateAndTime", "GameId", "PlayerId", "Score", "Status", "Target", "TurnId" },
                values: new object[,]
                {
                    { new Guid("11f764c1-682a-4527-b978-1dc1094234cb"), 0, new DateTime(2023, 1, 5, 16, 22, 8, 591, DateTimeKind.Local).AddTicks(6351), new Guid("3fa1ae29-3aed-433e-88e7-7d6264d535bd"), new Guid("0d7fc49d-61c4-41bd-ae39-e1551c5f4b89"), 0, 2, 17, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("5f9d70c4-bd65-4053-974a-91f7df01cede"), 0, new DateTime(2023, 1, 4, 16, 22, 8, 591, DateTimeKind.Local).AddTicks(6347), new Guid("3fa1ae29-3aed-433e-88e7-7d6264d535bd"), new Guid("0d7fc49d-61c4-41bd-ae39-e1551c5f4b89"), 0, 1, 15, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("b059700b-00bd-488e-a271-eb6555ac5cd6"), 0, new DateTime(2023, 1, 6, 16, 22, 8, 591, DateTimeKind.Local).AddTicks(6316), new Guid("3fa1ae29-3aed-433e-88e7-7d6264d535bd"), new Guid("0d7fc49d-61c4-41bd-ae39-e1551c5f4b89"), 0, 3, 16, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") }
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
