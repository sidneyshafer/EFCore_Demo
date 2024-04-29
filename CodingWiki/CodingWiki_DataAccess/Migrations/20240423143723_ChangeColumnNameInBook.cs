using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNameInBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Books_BooksBookId",
                table: "AuthorBook");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "Book_Id");

            migrationBuilder.RenameColumn(
                name: "BooksBookId",
                table: "AuthorBook",
                newName: "BooksBook_Id");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BooksBookId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BooksBook_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Books_BooksBook_Id",
                table: "AuthorBook",
                column: "BooksBook_Id",
                principalTable: "Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Books_BooksBook_Id",
                table: "AuthorBook");

            migrationBuilder.RenameColumn(
                name: "Book_Id",
                table: "Books",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "BooksBook_Id",
                table: "AuthorBook",
                newName: "BooksBookId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BooksBook_Id",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BooksBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Books_BooksBookId",
                table: "AuthorBook",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
