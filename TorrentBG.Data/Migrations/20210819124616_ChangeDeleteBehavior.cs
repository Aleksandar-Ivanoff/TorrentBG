using Microsoft.EntityFrameworkCore.Migrations;

namespace TorrentBG.Data.Migrations
{
    public partial class ChangeDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TorrentUser_AspNetUsers_UserId",
                table: "TorrentUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TorrentUser_Torrents_TorrentId",
                table: "TorrentUser");

            migrationBuilder.AddForeignKey(
                name: "FK_TorrentUser_AspNetUsers_UserId",
                table: "TorrentUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TorrentUser_Torrents_TorrentId",
                table: "TorrentUser",
                column: "TorrentId",
                principalTable: "Torrents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TorrentUser_AspNetUsers_UserId",
                table: "TorrentUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TorrentUser_Torrents_TorrentId",
                table: "TorrentUser");

            migrationBuilder.AddForeignKey(
                name: "FK_TorrentUser_AspNetUsers_UserId",
                table: "TorrentUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TorrentUser_Torrents_TorrentId",
                table: "TorrentUser",
                column: "TorrentId",
                principalTable: "Torrents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
