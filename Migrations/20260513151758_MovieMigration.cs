using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RazorPagesMovie.Migrations
{
    /// <inheritdoc />
    public partial class MovieMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BoxOfficeRevenue",
                table: "Movie",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Cast",
                table: "Movie",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movie",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ImdbRating",
                table: "Movie",
                type: "decimal(3,1)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseCountry",
                table: "Movie",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActor_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1942, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laurie Lesch" },
                    { 2, new DateTime(1968, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rhett Ullrich" },
                    { 3, new DateTime(1991, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivy Schoen" },
                    { 4, new DateTime(1981, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario Renner" },
                    { 5, new DateTime(1944, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nedra Buckridge" },
                    { 6, new DateTime(1967, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oda Gleichner" },
                    { 7, new DateTime(1945, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laney Stroman" },
                    { 8, new DateTime(1989, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clotilde Douglas" },
                    { 9, new DateTime(1950, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mose Goldner" },
                    { 10, new DateTime(1974, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ralph Littel" },
                    { 11, new DateTime(1949, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lilla Schmeler" },
                    { 12, new DateTime(1953, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marisa Paucek" },
                    { 13, new DateTime(1996, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terence Bauch" },
                    { 14, new DateTime(1952, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lera Dicki" },
                    { 15, new DateTime(1958, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natasha Wunsch" },
                    { 16, new DateTime(1974, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Margaret Breitenberg" },
                    { 17, new DateTime(2003, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raoul Kshlerin" },
                    { 18, new DateTime(1955, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Braxton Wolf" },
                    { 19, new DateTime(1961, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sheila Jacobi" },
                    { 20, new DateTime(1981, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doris Boyer" },
                    { 21, new DateTime(1957, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donnie Nitzsche" },
                    { 22, new DateTime(2000, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deshaun Beier" },
                    { 23, new DateTime(1968, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeanie Bergnaum" },
                    { 24, new DateTime(1954, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rudy Stark" },
                    { 25, new DateTime(1984, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kathleen Wuckert" },
                    { 26, new DateTime(1954, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofia Kling" },
                    { 27, new DateTime(1950, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jasen Beier" },
                    { 28, new DateTime(1943, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lou Zieme" },
                    { 29, new DateTime(1993, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keenan Kulas" },
                    { 30, new DateTime(1958, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabitha Schinner" },
                    { 31, new DateTime(2001, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shanelle Nolan" },
                    { 32, new DateTime(1975, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daryl Heaney" },
                    { 33, new DateTime(1999, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiana Kuhlman" },
                    { 34, new DateTime(1942, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Felipe Denesik" },
                    { 35, new DateTime(1980, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "August Williamson" },
                    { 36, new DateTime(2004, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nia Mayert" },
                    { 37, new DateTime(2001, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keely Zboncak" },
                    { 38, new DateTime(1942, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bertha Schinner" },
                    { 39, new DateTime(1981, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Janelle Nicolas" },
                    { 40, new DateTime(1976, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concepcion Predovic" },
                    { 41, new DateTime(1957, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bertram Mayer" },
                    { 42, new DateTime(1953, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bud Wolf" },
                    { 43, new DateTime(1981, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dylan Haley" },
                    { 44, new DateTime(2002, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Braxton Wisozk" },
                    { 45, new DateTime(1996, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eliezer Cassin" },
                    { 46, new DateTime(1942, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brady Little" },
                    { 47, new DateTime(1999, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hipolito Schoen" },
                    { 48, new DateTime(1992, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retha Heller" },
                    { 49, new DateTime(1994, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Everardo Runte" },
                    { 50, new DateTime(1985, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabitha Runolfsson" },
                    { 51, new DateTime(1991, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stevie Reichert" },
                    { 52, new DateTime(1979, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Felix Fisher" },
                    { 53, new DateTime(2003, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olen White" },
                    { 54, new DateTime(1957, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Helen Kozey" },
                    { 55, new DateTime(1941, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florine Keeling" },
                    { 56, new DateTime(1983, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilford Schulist" },
                    { 57, new DateTime(1945, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carolina Heathcote" },
                    { 58, new DateTime(1997, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lelia Rutherford" },
                    { 59, new DateTime(1954, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madisen Green" },
                    { 60, new DateTime(1953, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamaal Schmidt" },
                    { 61, new DateTime(1975, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Francisco Hilpert" },
                    { 62, new DateTime(1956, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Torrance Fahey" },
                    { 63, new DateTime(1997, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chadd West" },
                    { 64, new DateTime(1978, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dixie Hermann" },
                    { 65, new DateTime(1961, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anabelle Altenwerth" },
                    { 66, new DateTime(1999, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luz Konopelski" },
                    { 67, new DateTime(2002, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Otilia Hickle" },
                    { 68, new DateTime(1967, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chandler Rohan" },
                    { 69, new DateTime(2001, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesley Gulgowski" },
                    { 70, new DateTime(2001, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stevie Predovic" },
                    { 71, new DateTime(1949, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgiana Hackett" },
                    { 72, new DateTime(1946, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ora Beer" },
                    { 73, new DateTime(1953, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mike Kautzer" },
                    { 74, new DateTime(1996, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Onie Schneider" },
                    { 75, new DateTime(2004, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ozella Tremblay" },
                    { 76, new DateTime(1989, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jerrold Lowe" },
                    { 77, new DateTime(1993, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kattie Altenwerth" },
                    { 78, new DateTime(1968, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elody Parker" },
                    { 79, new DateTime(1980, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dennis Dickens" },
                    { 80, new DateTime(2000, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brady Hammes" },
                    { 81, new DateTime(1956, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eli Glover" },
                    { 82, new DateTime(1943, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Travon Torp" },
                    { 83, new DateTime(2001, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabella Goyette" },
                    { 84, new DateTime(1942, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Darron Waters" },
                    { 85, new DateTime(1976, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Micheal Adams" },
                    { 86, new DateTime(1995, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ashley Hudson" },
                    { 87, new DateTime(1988, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holden Buckridge" },
                    { 88, new DateTime(1984, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cielo Heller" },
                    { 89, new DateTime(1980, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Branson Blanda" },
                    { 90, new DateTime(1996, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Merritt Ledner" },
                    { 91, new DateTime(1946, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaunita Medhurst" },
                    { 92, new DateTime(1974, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dortha Kreiger" },
                    { 93, new DateTime(1940, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lew Stark" },
                    { 94, new DateTime(1957, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tyreek Beatty" },
                    { 95, new DateTime(1945, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ramiro Hamill" },
                    { 96, new DateTime(1983, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Otho McLaughlin" },
                    { 97, new DateTime(1991, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serena Cummerata" },
                    { 98, new DateTime(1953, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ocie Pouros" },
                    { 99, new DateTime(1999, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chester Brown" },
                    { 100, new DateTime(1992, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kelvin Schoen" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_ActorId",
                table: "MovieActor",
                column: "ActorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropColumn(
                name: "BoxOfficeRevenue",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Cast",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ImdbRating",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ReleaseCountry",
                table: "Movie");
        }
    }
}
