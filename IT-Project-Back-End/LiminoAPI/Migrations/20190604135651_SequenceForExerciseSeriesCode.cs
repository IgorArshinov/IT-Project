using Microsoft.EntityFrameworkCore.Migrations;

namespace LiminoAPI.Migrations
{
    public partial class SequenceForExerciseSeriesCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "liminoDb");

            migrationBuilder.RenameColumn(
                name: "Correct",
                table: "Answers",
                newName: "IsCorrect");

            migrationBuilder.CreateSequence<int>(
                name: "CodeNumbers",
                schema: "liminoDb",
                startValue: 1000L);

            migrationBuilder.AlterColumn<long>(
                name: "Code",
                table: "ExerciseSeries",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR liminoDb.CodeNumbers",
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "CodeNumbers",
                schema: "liminoDb");

            migrationBuilder.RenameColumn(
                name: "IsCorrect",
                table: "Answers",
                newName: "Correct");

            migrationBuilder.AlterColumn<long>(
                name: "Code",
                table: "ExerciseSeries",
                nullable: false,
                oldClrType: typeof(long),
                oldDefaultValueSql: "NEXT VALUE FOR liminoDb.CodeNumbers");
        }
    }
}
