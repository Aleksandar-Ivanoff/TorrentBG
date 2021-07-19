using Microsoft.EntityFrameworkCore.Migrations;

namespace TorrentBG.Data.Migrations
{
    public partial class UploaderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UploaderId",
                table: "Torrents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploaderId1",
                table: "Torrents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Uploaders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uploaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uploaders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Torrents_UploaderId",
                table: "Torrents",
                column: "UploaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Torrents_UploaderId1",
                table: "Torrents",
                column: "UploaderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Uploaders_UserId",
                table: "Uploaders",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Torrents_Uploaders_UploaderId",
                table: "Torrents",
                column: "UploaderId",
                principalTable: "Uploaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Torrents_Uploaders_UploaderId1",
                table: "Torrents",
                column: "UploaderId1",
                principalTable: "Uploaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Torrents_Uploaders_UploaderId",
                table: "Torrents");

            migrationBuilder.DropForeignKey(
                name: "FK_Torrents_Uploaders_UploaderId1",
                table: "Torrents");

            migrationBuilder.DropTable(
                name: "Uploaders");

            migrationBuilder.DropIndex(
                name: "IX_Torrents_UploaderId",
                table: "Torrents");

            migrationBuilder.DropIndex(
                name: "IX_Torrents_UploaderId1",
                table: "Torrents");

            migrationBuilder.DropColumn(
                name: "UploaderId",
                table: "Torrents");

            migrationBuilder.DropColumn(
                name: "UploaderId1",
                table: "Torrents");
        }
    }
}
