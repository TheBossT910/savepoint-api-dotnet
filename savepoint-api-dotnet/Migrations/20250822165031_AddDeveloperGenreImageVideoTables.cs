using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace savepoint_api_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddDeveloperGenreImageVideoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Developer_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genre_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Developer_GameId",
                table: "Developer",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_GameId",
                table: "Genre",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_GameId",
                table: "Image",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_GameId",
                table: "Video",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Video");
        }
    }
}
