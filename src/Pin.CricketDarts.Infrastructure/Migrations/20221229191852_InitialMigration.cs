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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                column: "Id",
                value: new Guid("243407c9-d7e6-4192-a465-71076a592bf9"));

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsActive", "TournamentId", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("0ebadcc7-c3ed-47c4-ba96-80e67f1fdbce"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("8acc734d-23b0-4efe-a949-deb6c2aa358f") },
                    { new Guid("2932ce9f-182b-4ec3-b038-9aea45322120"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("03a7db65-93ab-4c50-a9b7-6ebc3e79c4fd") },
                    { new Guid("33f3f798-02e8-4c8e-b82e-2cdc90095f23"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("2c5361aa-537f-4914-8f7a-1bca3dfedc88") },
                    { new Guid("3e119591-ccab-4dd4-bc44-bd638aa48081"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("f1a926e7-5e09-4541-b5a8-99c32e9d9f4f") },
                    { new Guid("63d5a480-e753-497b-8392-3230e811134f"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("7691dbc9-4f83-45f9-b453-aef0a431b179") },
                    { new Guid("e1ba239c-e7df-42df-b1d1-8b3c8dc75cd8"), false, new Guid("243407c9-d7e6-4192-a465-71076a592bf9"), new Guid("9c5cffc9-bd19-45e4-82f3-83094989bed6") }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "PersonalStatisticsId" },
                values: new object[,]
                {
                    { new Guid("03a7db65-93ab-4c50-a9b7-6ebc3e79c4fd"), "BruceWillis", new Guid("fcf8914b-061f-4e1c-af01-9fbb8f0847e9") },
                    { new Guid("2c5361aa-537f-4914-8f7a-1bca3dfedc88"), "TheWolf", new Guid("f49ac80b-e798-4ae6-8689-2016921e6a64") },
                    { new Guid("7691dbc9-4f83-45f9-b453-aef0a431b179"), "JohnTravolta", new Guid("1389d5cd-2fa1-4dfd-a422-c4e30e89686e") },
                    { new Guid("8acc734d-23b0-4efe-a949-deb6c2aa358f"), "VincentVega", new Guid("59062baa-5af2-483d-a683-8f982252a3d9") },
                    { new Guid("9c5cffc9-bd19-45e4-82f3-83094989bed6"), "Butch", new Guid("fd89d57c-01ea-4938-9061-4961c3ed02dc") },
                    { new Guid("f1a926e7-5e09-4541-b5a8-99c32e9d9f4f"), "Fabienne", new Guid("0928ac0b-b2f6-4189-9280-2318c8ab91d2") }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "GameId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("0ebadcc7-c3ed-47c4-ba96-80e67f1fdbce"), new Guid("03a7db65-93ab-4c50-a9b7-6ebc3e79c4fd") },
                    { new Guid("0ebadcc7-c3ed-47c4-ba96-80e67f1fdbce"), new Guid("8acc734d-23b0-4efe-a949-deb6c2aa358f") },
                    { new Guid("2932ce9f-182b-4ec3-b038-9aea45322120"), new Guid("9c5cffc9-bd19-45e4-82f3-83094989bed6") },
                    { new Guid("2932ce9f-182b-4ec3-b038-9aea45322120"), new Guid("f1a926e7-5e09-4541-b5a8-99c32e9d9f4f") },
                    { new Guid("3e119591-ccab-4dd4-bc44-bd638aa48081"), new Guid("2c5361aa-537f-4914-8f7a-1bca3dfedc88") },
                    { new Guid("3e119591-ccab-4dd4-bc44-bd638aa48081"), new Guid("7691dbc9-4f83-45f9-b453-aef0a431b179") }
                });

            migrationBuilder.InsertData(
                table: "Score",
                columns: new[] { "Id", "GameId", "PlayerId", "TotalScore" },
                values: new object[,]
                {
                    { new Guid("63d98bae-f359-4834-b403-29aefe9a0de4"), new Guid("0ebadcc7-c3ed-47c4-ba96-80e67f1fdbce"), new Guid("03a7db65-93ab-4c50-a9b7-6ebc3e79c4fd"), 40 },
                    { new Guid("846c807a-a5fe-453e-9946-d0a0591cbd03"), new Guid("3e119591-ccab-4dd4-bc44-bd638aa48081"), new Guid("7691dbc9-4f83-45f9-b453-aef0a431b179"), 54 },
                    { new Guid("898540a6-dae2-4e94-86b6-3babf6374aec"), new Guid("2932ce9f-182b-4ec3-b038-9aea45322120"), new Guid("f1a926e7-5e09-4541-b5a8-99c32e9d9f4f"), 2 },
                    { new Guid("899270e3-7e60-44a7-a490-96d1c1ba9356"), new Guid("3e119591-ccab-4dd4-bc44-bd638aa48081"), new Guid("2c5361aa-537f-4914-8f7a-1bca3dfedc88"), 4 },
                    { new Guid("91b5c15f-d156-427f-a942-66f5ad4cf18e"), new Guid("2932ce9f-182b-4ec3-b038-9aea45322120"), new Guid("9c5cffc9-bd19-45e4-82f3-83094989bed6"), 33 },
                    { new Guid("bdb8db85-e3e8-478b-bae9-84aaca48a8b6"), new Guid("0ebadcc7-c3ed-47c4-ba96-80e67f1fdbce"), new Guid("8acc734d-23b0-4efe-a949-deb6c2aa358f"), 20 }
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
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "PlayerStatistics");
        }
    }
}
