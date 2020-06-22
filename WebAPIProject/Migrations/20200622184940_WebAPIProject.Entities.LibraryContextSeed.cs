using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIProject.Migrations
{
    public partial class WebAPIProjectEntitiesLibraryContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "Genre", "LastName" },
                values: new object[] { new Guid("14020635-fbbc-473f-bbe1-fcd3e1f00ede"), "Bob", "Drama", "Ross" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "Genre", "LastName" },
                values: new object[] { new Guid("a135595e-45c4-443b-a9e0-6c98b4417275"), "David", "Fantasy", "Miller" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("14020635-fbbc-473f-bbe1-fcd3e1f00ede"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("a135595e-45c4-443b-a9e0-6c98b4417275"));
        }
    }
}
