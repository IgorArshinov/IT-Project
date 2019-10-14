using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiminoAPI.Migrations
{
    public partial class AddUserSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1L, null, new byte[] { 123, 133, 218, 252, 25, 103, 85, 105, 11, 237, 43, 164, 5, 159, 134, 10, 105, 186, 96, 67, 94, 51, 239, 10, 103, 51, 56, 13, 141, 90, 220, 86, 134, 211, 196, 37, 169, 83, 3, 182, 65, 206, 186, 69, 78, 40, 252, 42, 121, 165, 231, 251, 98, 236, 104, 243, 163, 121, 180, 220, 188, 101, 229, 116 }, new byte[] { 145, 124, 36, 189, 93, 32, 248, 179, 75, 31, 12, 220, 234, 227, 31, 105, 173, 116, 114, 108, 204, 225, 201, 88, 132, 254, 243, 157, 102, 95, 15, 46, 10, 152, 239, 107, 4, 40, 30, 240, 168, 170, 184, 50, 165, 76, 210, 14, 229, 11, 13, 31, 79, 43, 200, 8, 40, 171, 14, 94, 234, 83, 66, 115, 130, 36, 34, 119, 22, 148, 171, 214, 70, 44, 108, 182, 53, 189, 37, 76, 114, 91, 101, 211, 11, 210, 161, 66, 215, 177, 116, 248, 199, 53, 75, 144, 167, 255, 40, 35, 86, 13, 145, 246, 86, 174, 122, 193, 47, 96, 79, 67, 145, 174, 174, 244, 66, 101, 167, 26, 153, 35, 207, 241, 223, 151, 33, 46 }, "admin@limino.be" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
