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
                    Score = table.Column<int>(type: "int", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    { new Guid("55def332-3a75-48bf-9cd3-a0dfc316edbc"), 0, false, "TheWolf", 0, 0 },
                    { new Guid("7251954b-419b-4878-bf8c-90f9d2060cad"), 0, false, "Fabienne", 0, 0 },
                    { new Guid("74e61fca-578c-4f43-babf-ba9d940d5710"), 0, false, "BruceWillis", 0, 0 },
                    { new Guid("9a2ff821-d68f-4a15-a9a5-03b7fa70d270"), 0, false, "Butch", 0, 0 },
                    { new Guid("9cfecfb7-b553-41b7-8608-c34924cdff0e"), 0, false, "JohnTravolta", 0, 0 },
                    { new Guid("b4dfc89d-986d-4c10-bca5-3cf9a446c2fc"), 0, false, "VincentVega", 0, 0 }
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
                    { new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), 0, new Guid("74e61fca-578c-4f43-babf-ba9d940d5710"), 0 },
                    { new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59"), 3, new Guid("b4dfc89d-986d-4c10-bca5-3cf9a446c2fc"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CurrentTurnId", "IsActive", "TournamentId", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("1fba6e83-08e6-44c5-8464-8bcd8ee0624c"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("9cfecfb7-b553-41b7-8608-c34924cdff0e") },
                    { new Guid("4636bf3e-7dc9-4b13-9bd1-043d0c2c1ef5"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("74e61fca-578c-4f43-babf-ba9d940d5710") },
                    { new Guid("59b3f642-2c81-4081-9f9e-702a0faf8b5f"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("9a2ff821-d68f-4a15-a9a5-03b7fa70d270") },
                    { new Guid("84c593cb-2eae-4f30-924e-e7614c69b82d"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("b4dfc89d-986d-4c10-bca5-3cf9a446c2fc") },
                    { new Guid("853f526f-274c-4f33-8800-6a6c93cf2569"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("7251954b-419b-4878-bf8c-90f9d2060cad") },
                    { new Guid("b9627ad3-7788-4f79-bd46-f89266bece50"), new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), true, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("b9627ad3-7788-4f79-bd46-f89266bece50"), new Guid("74e61fca-578c-4f43-babf-ba9d940d5710") },
                    { new Guid("b9627ad3-7788-4f79-bd46-f89266bece50"), new Guid("b4dfc89d-986d-4c10-bca5-3cf9a446c2fc") }
                });

            migrationBuilder.InsertData(
                table: "ScoreBoardEntries",
                columns: new[] { "Id", "DateAndTime", "GameId", "PlayerId", "Score", "Status", "Target", "TurnId" },
                values: new object[,]
                {
                    { new Guid("bbb32969-bf85-43b3-addd-60d37384654e"), new DateTime(2023, 1, 5, 18, 39, 8, 636, DateTimeKind.Local).AddTicks(8219), new Guid("b9627ad3-7788-4f79-bd46-f89266bece50"), new Guid("b4dfc89d-986d-4c10-bca5-3cf9a446c2fc"), 0, 3, 16, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("c121b8f1-b7ac-4513-af35-d17c2c30e836"), new DateTime(2023, 1, 3, 18, 39, 8, 636, DateTimeKind.Local).AddTicks(8247), new Guid("b9627ad3-7788-4f79-bd46-f89266bece50"), new Guid("b4dfc89d-986d-4c10-bca5-3cf9a446c2fc"), 0, 1, 15, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("fea4d82c-ecba-4761-b741-682c61831dd7"), new DateTime(2023, 1, 4, 18, 39, 8, 636, DateTimeKind.Local).AddTicks(8251), new Guid("b9627ad3-7788-4f79-bd46-f89266bece50"), new Guid("b4dfc89d-986d-4c10-bca5-3cf9a446c2fc"), 0, 2, 17, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") }
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
