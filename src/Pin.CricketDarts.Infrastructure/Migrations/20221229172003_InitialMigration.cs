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
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsActive", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("1639ba16-201a-4afe-9ba0-4ad32c09a946"), false, new Guid("c30f9222-1472-494f-b647-80e02f66bd47") },
                    { new Guid("8fc41c15-dd12-4a56-b756-80ba94340835"), false, new Guid("64dbcd30-a68a-4fda-8a80-a2e6fba9fd07") },
                    { new Guid("aaddd93b-d992-4465-9cab-cbb6af9f14ee"), false, new Guid("2e4fe9ce-7976-4606-8a36-178201283e5b") },
                    { new Guid("ab805a0f-d119-4f7d-a6d7-079431e24438"), false, new Guid("053bfaa9-c5fb-4337-8a4c-bbc9eff7a05c") },
                    { new Guid("ecbabc2f-37d8-40b9-bb40-1e0000405b2f"), false, new Guid("6db32ec3-a002-4379-a602-d4b4bc240d6c") },
                    { new Guid("f0b8497d-8611-49a7-9cdb-ed71bf0a4ec5"), false, new Guid("c3c69a34-52e4-4578-abeb-9c96b152fc63") }
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
                table: "Players",
                columns: new[] { "Id", "Name", "PersonalStatisticsId" },
                values: new object[,]
                {
                    { new Guid("053bfaa9-c5fb-4337-8a4c-bbc9eff7a05c"), "TheWolf", new Guid("f49ac80b-e798-4ae6-8689-2016921e6a64") },
                    { new Guid("2e4fe9ce-7976-4606-8a36-178201283e5b"), "Fabienne", new Guid("0928ac0b-b2f6-4189-9280-2318c8ab91d2") },
                    { new Guid("64dbcd30-a68a-4fda-8a80-a2e6fba9fd07"), "VincentVega", new Guid("59062baa-5af2-483d-a683-8f982252a3d9") },
                    { new Guid("6db32ec3-a002-4379-a602-d4b4bc240d6c"), "JohnTravolta", new Guid("1389d5cd-2fa1-4dfd-a422-c4e30e89686e") },
                    { new Guid("c30f9222-1472-494f-b647-80e02f66bd47"), "BruceWillis", new Guid("fcf8914b-061f-4e1c-af01-9fbb8f0847e9") },
                    { new Guid("c3c69a34-52e4-4578-abeb-9c96b152fc63"), "Butch", new Guid("fd89d57c-01ea-4938-9061-4961c3ed02dc") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("1639ba16-201a-4afe-9ba0-4ad32c09a946"), new Guid("2e4fe9ce-7976-4606-8a36-178201283e5b") },
                    { new Guid("1639ba16-201a-4afe-9ba0-4ad32c09a946"), new Guid("c3c69a34-52e4-4578-abeb-9c96b152fc63") },
                    { new Guid("8fc41c15-dd12-4a56-b756-80ba94340835"), new Guid("64dbcd30-a68a-4fda-8a80-a2e6fba9fd07") },
                    { new Guid("8fc41c15-dd12-4a56-b756-80ba94340835"), new Guid("c30f9222-1472-494f-b647-80e02f66bd47") },
                    { new Guid("aaddd93b-d992-4465-9cab-cbb6af9f14ee"), new Guid("053bfaa9-c5fb-4337-8a4c-bbc9eff7a05c") },
                    { new Guid("aaddd93b-d992-4465-9cab-cbb6af9f14ee"), new Guid("6db32ec3-a002-4379-a602-d4b4bc240d6c") }
                });

            migrationBuilder.InsertData(
                table: "Score",
                columns: new[] { "Id", "GameId", "PlayerId", "TotalScore" },
                values: new object[,]
                {
                    { new Guid("13ee6594-bcfb-4c63-8271-85e28726ae58"), new Guid("1639ba16-201a-4afe-9ba0-4ad32c09a946"), new Guid("2e4fe9ce-7976-4606-8a36-178201283e5b"), 2 },
                    { new Guid("560fc099-17da-4c13-83bb-bd63b82a2f57"), new Guid("aaddd93b-d992-4465-9cab-cbb6af9f14ee"), new Guid("6db32ec3-a002-4379-a602-d4b4bc240d6c"), 54 },
                    { new Guid("663a41ae-ae9b-4c70-bdde-94e03d4ed26b"), new Guid("aaddd93b-d992-4465-9cab-cbb6af9f14ee"), new Guid("053bfaa9-c5fb-4337-8a4c-bbc9eff7a05c"), 4 },
                    { new Guid("7cd4c2d6-c3af-43e9-9a7b-1e4c65ce36d9"), new Guid("1639ba16-201a-4afe-9ba0-4ad32c09a946"), new Guid("c3c69a34-52e4-4578-abeb-9c96b152fc63"), 33 },
                    { new Guid("a8ae8737-4695-44bf-b76d-2bf6489e995d"), new Guid("8fc41c15-dd12-4a56-b756-80ba94340835"), new Guid("64dbcd30-a68a-4fda-8a80-a2e6fba9fd07"), 20 },
                    { new Guid("d3368807-1006-4757-9c82-3d4edd3caa11"), new Guid("8fc41c15-dd12-4a56-b756-80ba94340835"), new Guid("c30f9222-1472-494f-b647-80e02f66bd47"), 40 }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PlayerStatistics");
        }
    }
}
