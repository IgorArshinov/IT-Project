using System.Collections.Generic;
using LiminoAPI.Data.Models;


namespace LiminoAPI.Business
{
    public class ExerciseDTO
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public string QuestionUrl { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public List<AnswerDTO> Answers { get; set; }
        
        public Levels Level { get; set; }
        
        public override bool Equals(object obj)
        {
            if (!(obj is ExerciseDTO item))
            {
                return false;
            }

            return QuestionUrl.Equals(item.QuestionUrl);
        }

        public override int GetHashCode()
        {
            return QuestionUrl.GetHashCode();
        }
    }
}