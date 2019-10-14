using System.Collections.Generic;

namespace LiminoAPI.Business.Services
{
    public interface IExerciseSeriesService
    {
        IEnumerable<ExerciseSeriesDTO> GetAllSeries();
        ExerciseSeriesDTO GetById(long id);
        ExerciseSeriesDTO GetByCode(long code);
        ExerciseSeriesDTO Add(ExerciseSeriesDTO exerciseSeriesDTO);
        void Delete(long id);
        ExerciseSeriesDTO Update(ExerciseSeriesDTO exerciseSeriesDTO);
    }
}