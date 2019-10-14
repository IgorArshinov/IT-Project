using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiminoAPI.Data.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }       
        
        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }
        public long ExerciseId { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }
        public bool IsCorrect { get; set; }
    }
}