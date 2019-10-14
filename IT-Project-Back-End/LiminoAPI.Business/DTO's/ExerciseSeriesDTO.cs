using System.Collections.Generic;
using LiminoAPI.Data.Models;

namespace LiminoAPI.Business
{
    public class ExerciseSeriesDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Code { get; set; }
        public string Level { get; set; }
        
        public long[] Exercises { get; set; }
        
        public override bool Equals(object obj)
        {
            if (!(obj is ExerciseSeriesDTO item))
            {
                return false;
            }
            return Name.Equals(item.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}