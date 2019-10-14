using System.Collections.Generic;
using LiminoAPI.Data.Models;

namespace LiminoAPI.Data.Repositories.Interfaces
{
    public interface IExerciseSeriesRepository
    {
        ExerciseSeries Add(ExerciseSeries exerciseSeries);
        void Delete(long id);
        IEnumerable<ExerciseSeries> GetAll();
        ExerciseSeries GetById(long id);
        ExerciseSeries GetByCode(long code);
        ExerciseSeries Update(ExerciseSeries exerciseSeries);
        

    }
}