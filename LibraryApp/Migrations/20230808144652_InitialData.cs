using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Books",
                newName: "Genre");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Description", "Genre", "ISBN", "Title" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "John Doe", "Book for DB testing", "Adventure", "some ISBN here", "DB test adventure book" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Books",
                newName: "genre");
        }
    }
}
