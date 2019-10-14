using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiminoAPI.Migrations
{
    public partial class exerciseAndAnswersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    QuestionUrl = table.Column<string>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExerciseId = table.Column<long>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    AudioUrl = table.Column<string>(nullable: true),
                    Correct = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "food");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "traffic");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "drinks");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CategoryId", "Name", "QuestionUrl", "Type", "VideoUrl" },
                values: new object[,]
                {
                    { 1L, 1L, "First Question", "questionUrl", "Collage", "videoUrl" },
                    { 2L, 2L, "Second Question", "questionUrl2", "True Or False", "videoUrl2" },
                    { 3L, 3L, "Second Question", "questionUrl3", "Multiple Choice", "videoUrl3" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AudioUrl", "Correct", "ExerciseId", "ImageUrl" },
                values: new object[,]
                {
                    { 1L, "AudioUrl1", false, 1L, "ImgUrl1" },
                    { 2L, "AudioUrl2", false, 1L, "ImgUrl2" },
                    { 3L, "AudioUrl3", true, 1L, "ImgUrl3" },
                    { 4L, "AudioUrl1", false, 2L, "ImgUrl1" },
                    { 5L, "AudioUrl2", false, 2L, "ImgUrl2" },
                    { 6L, "AudioUrl3", true, 2L, "ImgUrl3" },
                    { 7L, "AudioUrl1", false, 3L, "ImgUrl1" },
                    { 8L, "AudioUrl2", false, 3L, "ImgUrl2" },
                    { 9L, "AudioUrl3", true, 3L, "ImgUrl3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ExerciseId",
                table: "Answers",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CategoryId",
                table: "Exercises",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "eten");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "verkeer");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "drinken");
        }
    }
}
