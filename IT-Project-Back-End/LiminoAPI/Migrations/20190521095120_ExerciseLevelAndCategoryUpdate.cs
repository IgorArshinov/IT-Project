using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiminoAPI.Migrations
{
    public partial class ExerciseLevelAndCategoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryType",
                table: "Categories");

/*            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true);*/

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Exercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Level",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Level",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Level",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Level",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Level",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Role",
                value: "Admin");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 2L, null, new byte[] { 123, 133, 218, 252, 25, 103, 85, 105, 11, 237, 43, 164, 5, 159, 134, 10, 105, 186, 96, 67, 94, 51, 239, 10, 103, 51, 56, 13, 141, 90, 220, 86, 134, 211, 196, 37, 169, 83, 3, 182, 65, 206, 186, 69, 78, 40, 252, 42, 121, 165, 231, 251, 98, 236, 104, 243, 163, 121, 180, 220, 188, 101, 229, 116 }, new byte[] { 145, 124, 36, 189, 93, 32, 248, 179, 75, 31, 12, 220, 234, 227, 31, 105, 173, 116, 114, 108, 204, 225, 201, 88, 132, 254, 243, 157, 102, 95, 15, 46, 10, 152, 239, 107, 4, 40, 30, 240, 168, 170, 184, 50, 165, 76, 210, 14, 229, 11, 13, 31, 79, 43, 200, 8, 40, 171, 14, 94, 234, 83, 66, 115, 130, 36, 34, 119, 22, 148, 171, 214, 70, 44, 108, 182, 53, 189, 37, 76, 114, 91, 101, 211, 11, 210, 161, 66, 215, 177, 116, 248, 199, 53, 75, 144, 167, 255, 40, 35, 86, 13, 145, 246, 86, 174, 122, 193, 47, 96, 79, 67, 145, 174, 174, 244, 66, 101, 167, 26, 153, 35, 207, 241, 223, 151, 33, 46 }, "User", "teacher@limino.be" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseSeries");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "CategoryType",
                table: "Categories",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CategoryType",
                value: "video");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41L,
                column: "CategoryType",
                value: "audio");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42L,
                column: "CategoryType",
                value: "conversation");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43L,
                column: "CategoryType",
                value: "conversation");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 44L,
                column: "CategoryType",
                value: "conversation");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 45L,
                column: "CategoryType",
                value: "conversation");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 46L,
                column: "CategoryType",
                value: "conversation");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 47L,
                column: "CategoryType",
                value: "conversation");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 48L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 49L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 51L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 53L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 54L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 55L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 56L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 57L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 58L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 59L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 60L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 61L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 62L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 63L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 64L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 65L,
                column: "CategoryType",
                value: "exercise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 66L,
                column: "CategoryType",
                value: "exercise");
        }
    }
}
