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
                name: "PlayerStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamesWon = table.Column<int>(type: "int", nullable: false),
                    GamesLost = table.Column<int>(type: "int", nullable: false),
                    TriplesThrown = table.Column<int>(type: "int", nullable: false),
                    DoublesThrown = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatistics", x => x.Id);
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
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalStatisticsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_PlayerStatistics_PersonalStatisticsId",
                        column: x => x.PersonalStatisticsId,
                        principalTable: "PlayerStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Score_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Score_Players_PlayerId",
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
                table: "PlayerStatistics",
                columns: new[] { "Id", "DoublesThrown", "GamesLost", "GamesWon", "TriplesThrown" },
                values: new object[,]
                {
                    { new Guid("0928ac0b-b2f6-4189-9280-2318c8ab91d2"), 52, 34, 6, 45 },
                    { new Guid("1389d5cd-2fa1-4dfd-a422-c4e30e89686e"), 22, 25, 77, 6 },
                    { new Guid("59062baa-5af2-483d-a683-8f982252a3d9"), 2, 2, 4, 3 },
                    { new Guid("f49ac80b-e798-4ae6-8689-2016921e6a64"), 33, 12, 4, 33 },
                    { new Guid("fcf8914b-061f-4e1c-af01-9fbb8f0847e9"), 53, 6, 22, 22 },
                    { new Guid("fd89d57c-01ea-4938-9061-4961c3ed02dc"), 53, 56, 4, 7 }
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
                    { new Guid("2c294f35-fc57-46aa-82f0-4bf5c9b5d662"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("26ab4304-83dc-4471-b308-664d422da18d") },
                    { new Guid("4bdc27b3-3856-4e12-b8d8-797a21a21ab7"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("24971afc-2c0a-4ef5-b9a4-e16f07959c88") },
                    { new Guid("69057bc0-0052-46c6-ab39-ace97b50293a"), true, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("93826af0-2c6f-4fd3-8657-0ce74b0df9fb"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("b8ce94dc-6119-465e-b77b-7d3493c747b6") },
                    { new Guid("a49cd714-9957-4cab-8896-c76b7c6b7494"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("464c80df-e323-487f-a9f4-dfb3ec67ee07") },
                    { new Guid("c14c5b24-c3bf-46f4-b283-e5f2c3d416f5"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("5656ed8b-28b9-438b-b54b-c8584eaec931") }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "PersonalStatisticsId" },
                values: new object[,]
                {
                    { new Guid("24971afc-2c0a-4ef5-b9a4-e16f07959c88"), "JohnTravolta", new Guid("1389d5cd-2fa1-4dfd-a422-c4e30e89686e") },
                    { new Guid("26ab4304-83dc-4471-b308-664d422da18d"), "VincentVega", new Guid("59062baa-5af2-483d-a683-8f982252a3d9") },
                    { new Guid("464c80df-e323-487f-a9f4-dfb3ec67ee07"), "Fabienne", new Guid("0928ac0b-b2f6-4189-9280-2318c8ab91d2") },
                    { new Guid("5656ed8b-28b9-438b-b54b-c8584eaec931"), "Butch", new Guid("fd89d57c-01ea-4938-9061-4961c3ed02dc") },
                    { new Guid("b8ce94dc-6119-465e-b77b-7d3493c747b6"), "BruceWillis", new Guid("fcf8914b-061f-4e1c-af01-9fbb8f0847e9") },
                    { new Guid("eba9b205-2e38-40b3-8b65-65ac588b28a8"), "TheWolf", new Guid("f49ac80b-e798-4ae6-8689-2016921e6a64") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("69057bc0-0052-46c6-ab39-ace97b50293a"), new Guid("26ab4304-83dc-4471-b308-664d422da18d") },
                    { new Guid("69057bc0-0052-46c6-ab39-ace97b50293a"), new Guid("b8ce94dc-6119-465e-b77b-7d3493c747b6") }
                });

            migrationBuilder.InsertData(
                table: "Score",
                columns: new[] { "Id", "GameId", "PlayerId", "TotalScore" },
                values: new object[,]
                {
                    { new Guid("1a841895-35ee-41c3-9896-6a6648e0db42"), new Guid("a49cd714-9957-4cab-8896-c76b7c6b7494"), new Guid("eba9b205-2e38-40b3-8b65-65ac588b28a8"), 4 },
                    { new Guid("4d5e2610-6eda-4bec-b7ad-b1b0876ec97b"), new Guid("2c294f35-fc57-46aa-82f0-4bf5c9b5d662"), new Guid("b8ce94dc-6119-465e-b77b-7d3493c747b6"), 40 },
                    { new Guid("b37e27b5-9035-42c8-970c-989e89a37927"), new Guid("a49cd714-9957-4cab-8896-c76b7c6b7494"), new Guid("24971afc-2c0a-4ef5-b9a4-e16f07959c88"), 54 },
                    { new Guid("d3e1cbd2-df80-4ffd-8c72-f0296ea2a767"), new Guid("2c294f35-fc57-46aa-82f0-4bf5c9b5d662"), new Guid("26ab4304-83dc-4471-b308-664d422da18d"), 20 },
                    { new Guid("e36157e5-5cd3-4e48-87c8-963466bd90ca"), new Guid("93826af0-2c6f-4fd3-8657-0ce74b0df9fb"), new Guid("5656ed8b-28b9-438b-b54b-c8584eaec931"), 33 },
                    { new Guid("e9aa1b2d-6978-4e92-bfca-25c54718164f"), new Guid("93826af0-2c6f-4fd3-8657-0ce74b0df9fb"), new Guid("464c80df-e323-487f-a9f4-dfb3ec67ee07"), 2 }
                });

            migrationBuilder.InsertData(
                table: "ScoreBoardEntries",
                columns: new[] { "Id", "GameId", "PlayerId", "Status", "Target" },
                values: new object[,]
                {
                    { new Guid("5af26494-c3eb-420c-bcf9-4f7d4a612adb"), new Guid("69057bc0-0052-46c6-ab39-ace97b50293a"), new Guid("b8ce94dc-6119-465e-b77b-7d3493c747b6"), 2, 17 },
                    { new Guid("915823a9-fbad-4df5-b0db-e4511ba155f9"), new Guid("69057bc0-0052-46c6-ab39-ace97b50293a"), new Guid("26ab4304-83dc-4471-b308-664d422da18d"), 1, 15 },
                    { new Guid("96b63186-e13d-40ee-8cbc-b68c757d64d1"), new Guid("69057bc0-0052-46c6-ab39-ace97b50293a"), new Guid("26ab4304-83dc-4471-b308-664d422da18d"), 3, 16 }
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
                name: "IX_Players_PersonalStatisticsId",
                table: "Players",
                column: "PersonalStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_GameId",
                table: "Score",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_PlayerId",
                table: "Score",
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
                name: "Score");

            migrationBuilder.DropTable(
                name: "ScoreBoardEntries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "PlayerStatistics");
        }
    }
}
