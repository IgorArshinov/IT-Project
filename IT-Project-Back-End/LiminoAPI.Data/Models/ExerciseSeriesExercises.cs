namespace LiminoAPI.Data.Models
{
    public class ExerciseSeriesExercises
    {
        public long ExerciseSeriesId { get; set; }
        public ExerciseSeries ExerciseSeries { get; set; }
        public long ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}