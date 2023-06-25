using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soa.Migrations
{
    public partial class check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorId",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Book",
                newName: "Genretype");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Author",
                newName: "Authorname");

            migrationBuilder.AddColumn<string>(
                name: "Authorname",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookId", "AuthorId", "Authorname", "Description", "GenreId", "Genretype", "Price", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, " page turner", 1, "Fiction", 5.99m, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gangsta Granny Strikes Again!" },
                    { 2, 2, null, "Throughout the series, Harry is described as having his father's perpetually untidy black hair, his mother's bright green eyes, and a lightning bolt-shaped scar on his forehead. He is further described as small and skinny for his age with a thin face and knobbly knees, and he wears Windsor glasses.", 2, "Fantasy", 5.99m, new DateTime(2000, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter collection" },
                    { 3, 3, null, "Naomi, Melvin, Pedro, and Poppy are just a few of the twenty-one rambunctious, funny, and talented baby frogs who share their stories in the Cat Kid Comic Club. Can Li’l Petey, Molly, and Flippy help the students express themselves through comics? The adventures in class and on paper unwind with mishaps and hilarity as the creative baby frogs experience the mistakes and progress that come with practice and persistence.", 3, "kid", 12.95m, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cat Kid Comic Club series" },
                    { 4, 4, null, "Mr Fox, a family man, goes back to his ways of stealing, unable to resist his animal instincts. However, he finds himself trapped when three farmers decide to kill him and his kind.", 4, "action", 6.50m, new DateTime(2009, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantastic Mr. Fox" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Authorname",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Genretype",
                table: "Book",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "Authorname",
                table: "Author",
                newName: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
