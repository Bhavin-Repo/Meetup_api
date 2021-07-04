using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetupApis.Migrations
{
    public partial class AddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "Participants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ProfessionId",
                table: "Participants",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Professions_ProfessionId",
                table: "Participants",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Professions_ProfessionId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_ProfessionId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "Participants");
        }
    }
}
