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
                    { new Guid("10e94ab2-34ca-456f-90ca-6c97ae71d943"), 0, false, "JohnTravolta", 0, 0 },
                    { new Guid("76db3852-c7c2-4b56-9217-1f9be8de52bf"), 0, false, "Fabienne", 0, 0 },
                    { new Guid("a83ffedd-16f0-44aa-8809-2de04ab3838a"), 0, false, "Butch", 0, 0 },
                    { new Guid("c99067d1-c494-4e0a-aea3-3906c4f91ff8"), 0, false, "TheWolf", 0, 0 },
                    { new Guid("db1e7836-d552-40ea-8fb2-e7360601f8d1"), 0, false, "BruceWillis", 0, 0 },
                    { new Guid("db60af73-4e20-4ed5-b56c-736cc1fc0f7a"), 0, false, "VincentVega", 0, 0 }
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
                    { new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), 0, new Guid("db1e7836-d552-40ea-8fb2-e7360601f8d1"), 0 },
                    { new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59"), 3, new Guid("db60af73-4e20-4ed5-b56c-736cc1fc0f7a"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CurrentTurnId", "IsActive", "TournamentId", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("30c13176-e8ac-413f-a164-9467aad80e28"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("76db3852-c7c2-4b56-9217-1f9be8de52bf") },
                    { new Guid("41472e98-194e-4ffc-90f6-61bac0de8c2e"), new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), true, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("88cb8c70-ae39-445a-bf6f-30e4c01f9540"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("db60af73-4e20-4ed5-b56c-736cc1fc0f7a") },
                    { new Guid("a064fad5-2d83-4d51-908a-3b809886571b"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("a83ffedd-16f0-44aa-8809-2de04ab3838a") },
                    { new Guid("e89d2326-1cdc-4f58-8966-c740c527efbd"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("db1e7836-d552-40ea-8fb2-e7360601f8d1") },
                    { new Guid("fd2efb9d-8d9d-4692-b2b9-71d553e36fdf"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("10e94ab2-34ca-456f-90ca-6c97ae71d943") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("41472e98-194e-4ffc-90f6-61bac0de8c2e"), new Guid("db1e7836-d552-40ea-8fb2-e7360601f8d1") },
                    { new Guid("41472e98-194e-4ffc-90f6-61bac0de8c2e"), new Guid("db60af73-4e20-4ed5-b56c-736cc1fc0f7a") }
                });

            migrationBuilder.InsertData(
                table: "ScoreBoardEntries",
                columns: new[] { "Id", "DateAndTime", "GameId", "PlayerId", "Score", "Status", "Target", "TurnId" },
                values: new object[,]
                {
                    { new Guid("bf2e7060-19da-473b-8bd4-bd57911c7d5e"), new DateTime(2023, 1, 2, 20, 25, 1, 641, DateTimeKind.Local).AddTicks(8525), new Guid("41472e98-194e-4ffc-90f6-61bac0de8c2e"), new Guid("db60af73-4e20-4ed5-b56c-736cc1fc0f7a"), 0, 1, 15, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("bfaa3cae-2c71-4822-95e1-d53344839d70"), new DateTime(2023, 1, 3, 20, 25, 1, 641, DateTimeKind.Local).AddTicks(8566), new Guid("41472e98-194e-4ffc-90f6-61bac0de8c2e"), new Guid("db60af73-4e20-4ed5-b56c-736cc1fc0f7a"), 0, 2, 17, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("f59bb65e-d953-4340-8b84-9d5d88a990da"), new DateTime(2023, 1, 4, 20, 25, 1, 641, DateTimeKind.Local).AddTicks(8495), new Guid("41472e98-194e-4ffc-90f6-61bac0de8c2e"), new Guid("db60af73-4e20-4ed5-b56c-736cc1fc0f7a"), 0, 3, 16, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") }
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
