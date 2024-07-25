using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventWhiz.Migrations
{
    /// <inheritdoc />
    public partial class addingImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("01f6a0e3-36f9-4da7-bba4-006347260d8b"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("6b00aa4a-32f6-4bdc-9c88-f6208d39e7d4"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("87a8ab1a-0cd7-484b-9413-becfd31cef03"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("9a87817d-c43d-4260-aa25-0335cf9bbaf8"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("a266a065-0c4f-458f-adcc-e84ce15d56a6"));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Code", "LocationImgURL", "Name" },
                values: new object[,]
                {
                    { new Guid("52208aca-98b8-4c05-ac26-c8915255f9cf"), "LOC005", "https://www.google.com", "Location 5" },
                    { new Guid("6407c114-6fe6-42be-a77c-29344ed4e26a"), "LOC002", "https://www.google.com", "Location 2" },
                    { new Guid("8ff18763-6785-4413-ae5e-c217e6406288"), "LOC004", "https://www.google.com", "Location 4" },
                    { new Guid("b54fc53b-1628-4902-9820-3c471a7da4d1"), "LOC001", "https://www.google.com", "Location 1" },
                    { new Guid("e4ba1491-6dff-4068-9ac0-9d8c5f6d2c0a"), "LOC003", "https://www.google.com", "Location 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("52208aca-98b8-4c05-ac26-c8915255f9cf"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("6407c114-6fe6-42be-a77c-29344ed4e26a"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("8ff18763-6785-4413-ae5e-c217e6406288"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("b54fc53b-1628-4902-9820-3c471a7da4d1"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("e4ba1491-6dff-4068-9ac0-9d8c5f6d2c0a"));

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Code", "LocationImgURL", "Name" },
                values: new object[,]
                {
                    { new Guid("01f6a0e3-36f9-4da7-bba4-006347260d8b"), "LOC004", "https://www.google.com", "Location 4" },
                    { new Guid("6b00aa4a-32f6-4bdc-9c88-f6208d39e7d4"), "LOC005", "https://www.google.com", "Location 5" },
                    { new Guid("87a8ab1a-0cd7-484b-9413-becfd31cef03"), "LOC001", "https://www.google.com", "Location 1" },
                    { new Guid("9a87817d-c43d-4260-aa25-0335cf9bbaf8"), "LOC002", "https://www.google.com", "Location 2" },
                    { new Guid("a266a065-0c4f-458f-adcc-e84ce15d56a6"), "LOC003", "https://www.google.com", "Location 3" }
                });
        }
    }
}
