using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetupApis.Migrations
{
    public partial class ProfessionSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Employed" });

            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Student" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
