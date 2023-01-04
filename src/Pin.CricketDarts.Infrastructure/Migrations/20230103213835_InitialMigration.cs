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
                    { new Guid("434f3335-dcd8-4b9f-aa61-320c0a1fc7ad"), 0, false, "JohnTravolta", 0, 0 },
                    { new Guid("4c017cd3-956c-42e2-a379-0af5680bced7"), 0, false, "BruceWillis", 0, 0 },
                    { new Guid("5365d84f-7cbd-4f4b-ba4b-87f16e30d701"), 0, false, "Butch", 0, 0 },
                    { new Guid("5bd7e63b-1d2e-44b7-95e5-220f1070f2a4"), 0, false, "TheWolf", 0, 0 },
                    { new Guid("628048f6-d745-4dc5-a748-21dd95104285"), 0, false, "VincentVega", 0, 0 },
                    { new Guid("bddf7617-8a8e-4bac-b831-d3c74d27257e"), 0, false, "Fabienne", 0, 0 }
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
                    { new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), 0, new Guid("4c017cd3-956c-42e2-a379-0af5680bced7"), 0, false },
                    { new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59"), 3, new Guid("628048f6-d745-4dc5-a748-21dd95104285"), 0, false }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CurrentTurnId", "IsActive", "TournamentId", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("09b11b52-bf19-454d-80ad-1867d6e548c7"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("4c017cd3-956c-42e2-a379-0af5680bced7") },
                    { new Guid("35a75e98-e0c8-4969-b276-c39a805d666e"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("5365d84f-7cbd-4f4b-ba4b-87f16e30d701") },
                    { new Guid("98c8246c-c2c7-4b58-a5ad-de32cd13a8a3"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("434f3335-dcd8-4b9f-aa61-320c0a1fc7ad") },
                    { new Guid("9fe20014-df1c-4ef1-9ad3-a79b752020ac"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("628048f6-d745-4dc5-a748-21dd95104285") },
                    { new Guid("a29ee8cc-c0b7-4864-af56-69591250e192"), null, false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("bddf7617-8a8e-4bac-b831-d3c74d27257e") },
                    { new Guid("e8f63df7-2bcb-48e2-9c32-294785a9a7d5"), new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), true, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("e8f63df7-2bcb-48e2-9c32-294785a9a7d5"), new Guid("4c017cd3-956c-42e2-a379-0af5680bced7") },
                    { new Guid("e8f63df7-2bcb-48e2-9c32-294785a9a7d5"), new Guid("628048f6-d745-4dc5-a748-21dd95104285") }
                });

            migrationBuilder.InsertData(
                table: "ScoreBoardEntries",
                columns: new[] { "Id", "DateAndTime", "GameId", "PlayerId", "Score", "Status", "Target", "TurnId" },
                values: new object[,]
                {
                    { new Guid("475e0624-9216-47f4-9519-7b84e1c3bd63"), new DateTime(2023, 1, 3, 22, 38, 35, 343, DateTimeKind.Local).AddTicks(3126), new Guid("e8f63df7-2bcb-48e2-9c32-294785a9a7d5"), new Guid("628048f6-d745-4dc5-a748-21dd95104285"), 0, 1, 15, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("564c4145-4253-43ae-8cd4-978d2a7c26a6"), new DateTime(2023, 1, 5, 22, 38, 35, 343, DateTimeKind.Local).AddTicks(3098), new Guid("e8f63df7-2bcb-48e2-9c32-294785a9a7d5"), new Guid("628048f6-d745-4dc5-a748-21dd95104285"), 0, 3, 16, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") },
                    { new Guid("d0ea75f0-4492-4c29-94c9-736ee6dafdf1"), new DateTime(2023, 1, 4, 22, 38, 35, 343, DateTimeKind.Local).AddTicks(3130), new Guid("e8f63df7-2bcb-48e2-9c32-294785a9a7d5"), new Guid("628048f6-d745-4dc5-a748-21dd95104285"), 0, 2, 17, new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59") }
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
