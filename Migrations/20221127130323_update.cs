using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soa.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Authorname",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Genretype",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Book",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Book",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Book",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The Lord of the Rings is the saga of a group of sometimes reluctant heroes who set forth to save their world from consummate evil.", "lord of the rings" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Harry Potter is a series of seven fantasy novels written by British author J. K. Rowling.", " harry potter" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin.", "game of thrones" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Bridget Jones, a thirty-something single working woman living in London. She writes about her career, self-image, vices, family, friends, and romantic relationships.", " bridget jones diary" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 5, "The story follows the experiences of seven children as they are terrorized by an evil entity that exploits the fears of its victims to disguise itself while hunting its prey", "1t" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Book",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Book",
                newName: "GenreId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Book",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Authorname",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genretype",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Book",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "BookId");

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Authorname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

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
    }
}
