using Microsoft.EntityFrameworkCore.Migrations;

namespace CognizantChallengeDAL.Migrations
{
    public partial class CreateExpectedResultColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpectedResult",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedResult",
                table: "Tasks");
        }
    }
}
