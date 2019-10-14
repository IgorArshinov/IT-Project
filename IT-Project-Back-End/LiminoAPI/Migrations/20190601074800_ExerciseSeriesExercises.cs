using Microsoft.EntityFrameworkCore.Migrations;

namespace LiminoAPI.Migrations
{
    public partial class ExerciseSeriesExercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Code",
                table: "ExerciseSeries",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "ExerciseSeries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExerciseSeriesExercises",
                columns: table => new
                {
                    ExerciseSeriesId = table.Column<long>(nullable: false),
                    ExerciseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSeriesExercises", x => new { x.ExerciseId, x.ExerciseSeriesId });
                    table.ForeignKey(
                        name: "FK_ExerciseSeriesExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSeriesExercises_ExerciseSeries_ExerciseSeriesId",
                        column: x => x.ExerciseSeriesId,
                        principalTable: "ExerciseSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSeriesExercises_ExerciseSeriesId",
                table: "ExerciseSeriesExercises",
                column: "ExerciseSeriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseSeriesExercises");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ExerciseSeries");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "ExerciseSeries");
        }
    }
}
