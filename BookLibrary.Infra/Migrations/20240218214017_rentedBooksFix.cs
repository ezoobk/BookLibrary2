using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibrary2.Infra.Migrations
{
    public partial class rentedBooksFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentedBooks_books_BookId1",
                table: "rentedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_rentedBooks_members_MemberId1",
                table: "rentedBooks");

            migrationBuilder.DropIndex(
                name: "IX_rentedBooks_BookId1",
                table: "rentedBooks");

            migrationBuilder.DropIndex(
                name: "IX_rentedBooks_MemberId1",
                table: "rentedBooks");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "rentedBooks");

            migrationBuilder.DropColumn(
                name: "MemberId1",
                table: "rentedBooks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId1",
                table: "rentedBooks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId1",
                table: "rentedBooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_rentedBooks_BookId1",
                table: "rentedBooks",
                column: "BookId1");

            migrationBuilder.CreateIndex(
                name: "IX_rentedBooks_MemberId1",
                table: "rentedBooks",
                column: "MemberId1");

            migrationBuilder.AddForeignKey(
                name: "FK_rentedBooks_books_BookId1",
                table: "rentedBooks",
                column: "BookId1",
                principalTable: "books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rentedBooks_members_MemberId1",
                table: "rentedBooks",
                column: "MemberId1",
                principalTable: "members",
                principalColumn: "Id");
        }
    }
}
