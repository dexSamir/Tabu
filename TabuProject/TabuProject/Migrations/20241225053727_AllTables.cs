using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TabuProject.Migrations
{
    /// <inheritdoc />
    public partial class AllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Code = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Icon = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BannedWordCount = table.Column<int>(type: "integer", nullable: false),
                    FailCount = table.Column<int>(type: "integer", nullable: false),
                    SkipCount = table.Column<int>(type: "integer", nullable: false),
                    Second = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: true),
                    SuccessAnswer = table.Column<int>(type: "integer", nullable: true),
                    WrongAnswer = table.Column<int>(type: "integer", nullable: true),
                    LangCode = table.Column<string>(type: "character(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Languages_LangCode",
                        column: x => x.LangCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    LangCode = table.Column<string>(type: "character(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Languages_LangCode",
                        column: x => x.LangCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BannedWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    WordId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannedWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BannedWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannedWords_WordId",
                table: "BannedWords",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LangCode",
                table: "Games",
                column: "LangCode");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_LangCode",
                table: "Words",
                column: "LangCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannedWords");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
