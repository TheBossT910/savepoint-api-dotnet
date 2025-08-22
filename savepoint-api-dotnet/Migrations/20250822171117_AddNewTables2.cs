using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace savepoint_api_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameImage");

            migrationBuilder.DropTable(
                name: "GameVideo");

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "videos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_videos_GameId",
                table: "videos",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_images_GameId",
                table: "images",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_images_games_GameId",
                table: "images",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_videos_games_GameId",
                table: "videos",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_games_GameId",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_videos_games_GameId",
                table: "videos");

            migrationBuilder.DropIndex(
                name: "IX_videos_GameId",
                table: "videos");

            migrationBuilder.DropIndex(
                name: "IX_images_GameId",
                table: "images");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "videos");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "images");

            migrationBuilder.CreateTable(
                name: "GameImage",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameImage", x => new { x.GamesId, x.ImagesId });
                    table.ForeignKey(
                        name: "FK_GameImage_games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameImage_images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameVideo",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VideosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameVideo", x => new { x.GamesId, x.VideosId });
                    table.ForeignKey(
                        name: "FK_GameVideo_games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameVideo_videos_VideosId",
                        column: x => x.VideosId,
                        principalTable: "videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameImage_ImagesId",
                table: "GameImage",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameVideo_VideosId",
                table: "GameVideo",
                column: "VideosId");
        }
    }
}
