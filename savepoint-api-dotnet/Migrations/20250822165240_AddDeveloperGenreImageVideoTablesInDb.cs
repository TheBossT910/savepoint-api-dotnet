using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace savepoint_api_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddDeveloperGenreImageVideoTablesInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developer_games_GameId",
                table: "Developer");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_games_GameId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_games_GameId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_games_GameId",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Video",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Developer",
                table: "Developer");

            migrationBuilder.RenameTable(
                name: "Video",
                newName: "Videos");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "Developer",
                newName: "Developers");

            migrationBuilder.RenameIndex(
                name: "IX_Video_GameId",
                table: "Videos",
                newName: "IX_Videos_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Image_GameId",
                table: "Images",
                newName: "IX_Images_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Genre_GameId",
                table: "Genres",
                newName: "IX_Genres_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Developer_GameId",
                table: "Developers",
                newName: "IX_Developers_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Developers",
                table: "Developers",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Developers",
                table: "Developers");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "Video");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Image");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "Developers",
                newName: "Developer");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_GameId",
                table: "Video",
                newName: "IX_Video_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_GameId",
                table: "Image",
                newName: "IX_Image_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Genres_GameId",
                table: "Genre",
                newName: "IX_Genre_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Developers_GameId",
                table: "Developer",
                newName: "IX_Developer_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Video",
                table: "Video",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Developer",
                table: "Developer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Developer_games_GameId",
                table: "Developer",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_games_GameId",
                table: "Genre",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_games_GameId",
                table: "Image",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_games_GameId",
                table: "Video",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id");
        }
    }
}
