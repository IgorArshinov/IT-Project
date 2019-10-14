using Microsoft.EntityFrameworkCore.Migrations;

namespace LiminoAPI.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "ImageUrl", "Name" },
                values: new object[] { 1L, "Video", "imageUrl1", "eten" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "ImageUrl", "Name" },
                values: new object[] { 2L, "Audio", "imageUrl2", "verkeer" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "ImageUrl", "Name" },
                values: new object[] { 3L, "Audio", "imageUrl3", "drinken" });

            migrationBuilder.InsertData(
                table: "Audios",
                columns: new[] { "Id", "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, "audioUrl1", "imageUrl4", "Dit is een banaan" },
                    { 2L, 1L, "audioUrl3", "imageUrl7", "Dit is een appel" },
                    { 3L, 2L, "audioUrl2", "imageUrl5", "welke bus moet ik nemen?" },
                    { 4L, 2L, "audioUrl2", "imageUrl8", "hoe neem ik een taxi?" },
                    { 5L, 3L, "audioUrl3", "imageUrl5", "Mag ik een glas water?" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CategoryId", "Name", "VideoUrl" },
                values: new object[,]
                {
                    { 1L, 1L, "Video van een banaan", "VideoUrl1" },
                    { 4L, 1L, "Video van een appel", "VideoUrl2" },
                    { 2L, 2L, "Video van een bus", "VideoUrl2" },
                    { 3L, 3L, "Video van een glas water", "VideoUrl3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
