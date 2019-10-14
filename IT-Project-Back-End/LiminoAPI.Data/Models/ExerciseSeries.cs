using System.Collections.Generic;

namespace LiminoAPI.Data.Models
{
    public class ExerciseSeries : BaseEntity
    {
        public long Code { get; set; }
        public string Level { get; set; }
        
        public ICollection<ExerciseSeriesExercises> ExerciseSeriesExercises { get; set; }
        
        public override bool Equals(object obj)
        {
            if (!(obj is ExerciseSeries exerciseSeries))
            {
                return false;
            }

            return Name.Equals(exerciseSeries.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}