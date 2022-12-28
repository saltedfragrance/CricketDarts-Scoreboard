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
                    ActiveGame = table.Column<bool>(type: "bit", nullable: false),
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
                columns: new[] { "Id", "ActiveGame", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("02a34123-2c0a-44fd-bc0f-0b2811a0bf49"), false, new Guid("d5075f8b-2790-4454-9fb3-214d617f6c01") },
                    { new Guid("5e066679-39e5-4bf8-a26b-b1f0e49a68df"), false, new Guid("d6bc8afc-f051-4741-934d-a2a00443c201") },
                    { new Guid("5e6315c8-cce0-464b-b913-f74bfac8304f"), false, new Guid("790c2820-f1d4-4298-994b-44d281481ad8") },
                    { new Guid("82bfb14d-bcff-46d3-8dab-66498cf4d5bc"), false, new Guid("f08854d9-e0ae-47a6-b7c9-8a14e9af194b") },
                    { new Guid("ed06932d-ec42-4de5-83d7-395093100219"), false, new Guid("8afe52ab-f3a4-4742-b4f7-67e54b2a2dc8") },
                    { new Guid("f97cc947-64b3-4989-a0b5-4429e86cfeda"), false, new Guid("8354dbbb-6d2c-4a0f-aad9-64b4fdc27dfe") }
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
                    { new Guid("790c2820-f1d4-4298-994b-44d281481ad8"), "JohnTravolta", new Guid("1389d5cd-2fa1-4dfd-a422-c4e30e89686e") },
                    { new Guid("8354dbbb-6d2c-4a0f-aad9-64b4fdc27dfe"), "Butch", new Guid("fd89d57c-01ea-4938-9061-4961c3ed02dc") },
                    { new Guid("8afe52ab-f3a4-4742-b4f7-67e54b2a2dc8"), "VincentVega", new Guid("59062baa-5af2-483d-a683-8f982252a3d9") },
                    { new Guid("d5075f8b-2790-4454-9fb3-214d617f6c01"), "TheWolf", new Guid("f49ac80b-e798-4ae6-8689-2016921e6a64") },
                    { new Guid("d6bc8afc-f051-4741-934d-a2a00443c201"), "Fabienne", new Guid("0928ac0b-b2f6-4189-9280-2318c8ab91d2") },
                    { new Guid("f08854d9-e0ae-47a6-b7c9-8a14e9af194b"), "BruceWillis", new Guid("fcf8914b-061f-4e1c-af01-9fbb8f0847e9") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("5e066679-39e5-4bf8-a26b-b1f0e49a68df"), new Guid("790c2820-f1d4-4298-994b-44d281481ad8") },
                    { new Guid("5e066679-39e5-4bf8-a26b-b1f0e49a68df"), new Guid("d5075f8b-2790-4454-9fb3-214d617f6c01") },
                    { new Guid("82bfb14d-bcff-46d3-8dab-66498cf4d5bc"), new Guid("8354dbbb-6d2c-4a0f-aad9-64b4fdc27dfe") },
                    { new Guid("82bfb14d-bcff-46d3-8dab-66498cf4d5bc"), new Guid("d6bc8afc-f051-4741-934d-a2a00443c201") },
                    { new Guid("ed06932d-ec42-4de5-83d7-395093100219"), new Guid("8afe52ab-f3a4-4742-b4f7-67e54b2a2dc8") },
                    { new Guid("ed06932d-ec42-4de5-83d7-395093100219"), new Guid("f08854d9-e0ae-47a6-b7c9-8a14e9af194b") }
                });

            migrationBuilder.InsertData(
                table: "Score",
                columns: new[] { "Id", "GameId", "PlayerId", "TotalScore" },
                values: new object[,]
                {
                    { new Guid("1f0124ee-3923-4a07-806e-7c450fa06803"), new Guid("5e066679-39e5-4bf8-a26b-b1f0e49a68df"), new Guid("d5075f8b-2790-4454-9fb3-214d617f6c01"), 4 },
                    { new Guid("25441e34-b16e-447c-bbdd-a3c24df2aecf"), new Guid("ed06932d-ec42-4de5-83d7-395093100219"), new Guid("f08854d9-e0ae-47a6-b7c9-8a14e9af194b"), 40 },
                    { new Guid("72b81fae-1b16-4d18-bd1c-d6d07df277b3"), new Guid("5e066679-39e5-4bf8-a26b-b1f0e49a68df"), new Guid("790c2820-f1d4-4298-994b-44d281481ad8"), 54 },
                    { new Guid("8d42a98b-24b8-4e36-8886-b419ec12a998"), new Guid("ed06932d-ec42-4de5-83d7-395093100219"), new Guid("8afe52ab-f3a4-4742-b4f7-67e54b2a2dc8"), 20 },
                    { new Guid("91a663b7-7dee-4709-98c6-bedbd1b22241"), new Guid("82bfb14d-bcff-46d3-8dab-66498cf4d5bc"), new Guid("8354dbbb-6d2c-4a0f-aad9-64b4fdc27dfe"), 33 },
                    { new Guid("d3195e38-6b3b-4f6b-9667-86ea882a592e"), new Guid("82bfb14d-bcff-46d3-8dab-66498cf4d5bc"), new Guid("d6bc8afc-f051-4741-934d-a2a00443c201"), 2 }
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
