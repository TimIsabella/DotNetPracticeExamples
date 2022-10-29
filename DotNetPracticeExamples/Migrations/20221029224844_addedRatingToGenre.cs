using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetPracticeExamples.Migrations
{
    public partial class addedRatingToGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Genre",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 44);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 55);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: 77);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rating",
                value: 88);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rating",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 10,
                column: "Rating",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 11,
                column: "Rating",
                value: 22);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Genre");
        }
    }
}
