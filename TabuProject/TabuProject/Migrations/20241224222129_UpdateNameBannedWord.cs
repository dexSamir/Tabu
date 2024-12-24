using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabuProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameBannedWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bannedWords_Words_WordId",
                table: "bannedWords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bannedWords",
                table: "bannedWords");

            migrationBuilder.RenameTable(
                name: "bannedWords",
                newName: "BannedWords");

            migrationBuilder.RenameIndex(
                name: "IX_bannedWords_WordId",
                table: "BannedWords",
                newName: "IX_BannedWords_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BannedWords",
                table: "BannedWords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BannedWords_Words_WordId",
                table: "BannedWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannedWords_Words_WordId",
                table: "BannedWords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BannedWords",
                table: "BannedWords");

            migrationBuilder.RenameTable(
                name: "BannedWords",
                newName: "bannedWords");

            migrationBuilder.RenameIndex(
                name: "IX_BannedWords_WordId",
                table: "bannedWords",
                newName: "IX_bannedWords_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bannedWords",
                table: "bannedWords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bannedWords_Words_WordId",
                table: "bannedWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
