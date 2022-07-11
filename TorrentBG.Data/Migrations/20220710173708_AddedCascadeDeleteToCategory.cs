using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorrentBG.Data.Migrations
{
    public partial class AddedCascadeDeleteToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Torrents_Categories_CategoryId",
                table: "Torrents");

            migrationBuilder.AddForeignKey(
                name: "FK_Torrents_Categories_CategoryId",
                table: "Torrents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Torrents_Categories_CategoryId",
                table: "Torrents");

            migrationBuilder.AddForeignKey(
                name: "FK_Torrents_Categories_CategoryId",
                table: "Torrents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
