using Microsoft.EntityFrameworkCore.Migrations;

namespace TestDataBase.Migrations
{
    public partial class DiscriptionOfStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discription",
                table: "Students");
        }
    }
}
