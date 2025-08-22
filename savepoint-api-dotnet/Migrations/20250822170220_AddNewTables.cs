using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace savepoint_api_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperGame_Developers_DevelopersId",
                table: "DeveloperGame");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genres_GenresId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameImage_Images_ImagesId",
                table: "GameImage");

            migrationBuilder.DropForeignKey(
                name: "FK_GameVideo_Videos_VideosId",
                table: "GameVideo");

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
                newName: "videos");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "images");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "genres");

            migrationBuilder.RenameTable(
                name: "Developers",
                newName: "developers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_videos",
                table: "videos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_images",
                table: "images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genres",
                table: "genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_developers",
                table: "developers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperGame_developers_DevelopersId",
                table: "DeveloperGame",
                column: "DevelopersId",
                principalTable: "developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_genres_GenresId",
                table: "GameGenre",
                column: "GenresId",
                principalTable: "genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameImage_images_ImagesId",
                table: "GameImage",
                column: "ImagesId",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameVideo_videos_VideosId",
                table: "GameVideo",
                column: "VideosId",
                principalTable: "videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperGame_developers_DevelopersId",
                table: "DeveloperGame");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_genres_GenresId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameImage_images_ImagesId",
                table: "GameImage");

            migrationBuilder.DropForeignKey(
                name: "FK_GameVideo_videos_VideosId",
                table: "GameVideo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_videos",
                table: "videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_images",
                table: "images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genres",
                table: "genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_developers",
                table: "developers");

            migrationBuilder.RenameTable(
                name: "videos",
                newName: "Videos");

            migrationBuilder.RenameTable(
                name: "images",
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "genres",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "developers",
                newName: "Developers");

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
                name: "FK_DeveloperGame_Developers_DevelopersId",
                table: "DeveloperGame",
                column: "DevelopersId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genres_GenresId",
                table: "GameGenre",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameImage_Images_ImagesId",
                table: "GameImage",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameVideo_Videos_VideosId",
                table: "GameVideo",
                column: "VideosId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
