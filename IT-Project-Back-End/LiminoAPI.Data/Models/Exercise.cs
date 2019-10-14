using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiminoAPI.Data.Models
{
    public class Exercise : BaseEntity
    {
        public string Type { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string QuestionUrl { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public Levels Level { get; set; }
        public List<Answer> Answers { get; set; }
        
        public ICollection<ExerciseSeriesExercises> ExerciseSeriesExercises { get; set; }

        
        public override bool Equals(object obj)
        {
            if (!(obj is Exercise exercise))
            {
                return false;
            }

            return QuestionUrl.Equals(exercise.QuestionUrl);
        }

        public override int GetHashCode()
        {
            return QuestionUrl.GetHashCode();
        }
    }
}