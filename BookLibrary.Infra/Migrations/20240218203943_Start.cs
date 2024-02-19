using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibrary2.Infra.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qnantity = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_bookAuthors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "bookAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_bookCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "bookCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rentedBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptNum = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Returnd = table.Column<bool>(type: "bit", nullable: false),
                    BookId1 = table.Column<int>(type: "int", nullable: true),
                    MemberId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentedBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rentedBooks_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rentedBooks_books_BookId1",
                        column: x => x.BookId1,
                        principalTable: "books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_rentedBooks_members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rentedBooks_members_MemberId1",
                        column: x => x.MemberId1,
                        principalTable: "members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_AuthorId",
                table: "books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_books_CategoryId",
                table: "books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_rentedBooks_BookId",
                table: "rentedBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_rentedBooks_BookId1",
                table: "rentedBooks",
                column: "BookId1");

            migrationBuilder.CreateIndex(
                name: "IX_rentedBooks_MemberId",
                table: "rentedBooks",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_rentedBooks_MemberId1",
                table: "rentedBooks",
                column: "MemberId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rentedBooks");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "bookAuthors");

            migrationBuilder.DropTable(
                name: "bookCategories");
        }
    }
}
