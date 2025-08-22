using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace savepoint_api_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddDeveloperGenreImageVideoTablesRelationshipWithGamesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_games_GameId",
                table: "Developers");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_games_GameId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_games_GameId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_games_GameId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_GameId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Images_GameId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Genres_GameId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Developers_GameId",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Developers");

            migrationBuilder.CreateTable(
                name: "DeveloperGame",
                columns: table => new
                {
                    DevelopersId = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperGame", x => new { x.DevelopersId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_DeveloperGame_Developers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperGame_games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenre", x => new { x.GamesId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_GameGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenre_games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_GameImage_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameImage_games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "games",
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
                        name: "FK_GameVideo_Videos_VideosId",
                        column: x => x.VideosId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameVideo_games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperGame_GamesId",
                table: "DeveloperGame",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenresId",
                table: "GameGenre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_GameImage_ImagesId",
                table: "GameImage",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameVideo_VideosId",
                table: "GameVideo",
                column: "VideosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperGame");

            migrationBuilder.DropTable(
                name: "GameGenre");

            migrationBuilder.DropTable(
                name: "GameImage");

            migrationBuilder.DropTable(
                name: "GameVideo");

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "Videos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "Genres",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "Developers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_GameId",
                table: "Videos",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_GameId",
                table: "Images",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameId",
                table: "Genres",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_GameId",
                table: "Developers",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_games_GameId",
                table: "Developers",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_games_GameId",
                table: "Genres",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_games_GameId",
                table: "Images",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_games_GameId",
                table: "Videos",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id");
        }
    }
}
