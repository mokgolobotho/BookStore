using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class AddingImageDbSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "UsersEntity",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "BooksEntity",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "BooksEntity",
                newName: "Genre");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BooksEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BooksEntity");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UsersEntity",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "BooksEntity",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "BooksEntity",
                newName: "genre");
        }
    }
}
