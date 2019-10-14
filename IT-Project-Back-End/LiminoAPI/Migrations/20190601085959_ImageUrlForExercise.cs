using Microsoft.EntityFrameworkCore.Migrations;

namespace LiminoAPI.Migrations
{
    public partial class ImageUrlForExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Exercises",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Exercises");
        }
    }
}
