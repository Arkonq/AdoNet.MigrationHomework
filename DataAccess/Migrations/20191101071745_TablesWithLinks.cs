using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class TablesWithLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VisitorId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BooksAuthors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    BookId = table.Column<Guid>(nullable: true),
                    AuthorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BooksAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_VisitorId",
                table: "Books",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksAuthors_AuthorId",
                table: "BooksAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksAuthors_BookId",
                table: "BooksAuthors",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Visitors_VisitorId",
                table: "Books",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Visitors_VisitorId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BooksAuthors");

            migrationBuilder.DropIndex(
                name: "IX_Books_VisitorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "VisitorId",
                table: "Books");
        }
    }
}
