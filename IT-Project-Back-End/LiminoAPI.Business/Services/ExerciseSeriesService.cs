using System.Collections.Generic;
using System.Linq;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;

namespace LiminoAPI.Business.Services
{
    public class ExerciseSeriesService : IExerciseSeriesService
    {
        private readonly IExerciseSeriesRepository _repository;

        private readonly IBaseRepository<Exercise> _exerciseRepository;

        public ExerciseSeriesService(IExerciseSeriesRepository baseRepository, IBaseRepository<Exercise> exerciseRepository)
        {
            _repository = baseRepository;
            _exerciseRepository = exerciseRepository;
        }

        public IEnumerable<ExerciseSeriesDTO> GetAllSeries()
        {
            var exerciseSeriesList = _repository.GetAll();
            return MapExerciseSeriesListToExerciseSeriesDTOList(exerciseSeriesList);
        }

        public ExerciseSeriesDTO GetById(long id)
        {
            var exerciseSeries = _repository.GetById(id);
            return MapExerciseSeriesToExerciseSeriesDTO(exerciseSeries);
        }

        public ExerciseSeriesDTO GetByCode(long code)
        {
            var exerciseSeries = _repository.GetByCode(code);
            return MapExerciseSeriesToExerciseSeriesDTO(exerciseSeries);
        }

        public ExerciseSeriesDTO Add(ExerciseSeriesDTO exerciseSeriesDTO)
        {
            var exerciseSeries = _repository.Add(MapExerciseSeriesDTOtoExerciseSeries(exerciseSeriesDTO));
            return MapExerciseSeriesToExerciseSeriesDTO(exerciseSeries);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public ExerciseSeriesDTO Update(ExerciseSeriesDTO exerciseSeriesDTO)
        {
            var exerciseSeries = MapExerciseSeriesDTOtoExerciseSeries(exerciseSeriesDTO);
            return MapExerciseSeriesToExerciseSeriesDTO(_repository.Update(exerciseSeries));
        }

        private static ExerciseSeries MapExerciseSeriesDTOtoExerciseSeries(ExerciseSeriesDTO exerciseSeriesDTO)
        {
            return new ExerciseSeries
            {
                Id = exerciseSeriesDTO.Id,
                Name = exerciseSeriesDTO.Name,
                Level = exerciseSeriesDTO.Level,
                ExerciseSeriesExercises = exerciseSeriesDTO.Exercises.Select(exerciseId => new ExerciseSeriesExercises
                {
                    ExerciseId = exerciseId,
                    ExerciseSeriesId = exerciseSeriesDTO.Id
                }).ToList()
            };
        }

        private ExerciseSeriesDTO MapExerciseSeriesToExerciseSeriesDTO(ExerciseSeries exerciseSeries)
        {
            return new ExerciseSeriesDTO
            {
                Id = exerciseSeries.Id,
                Name = exerciseSeries.Name,
                Code = exerciseSeries.Code,
                Level = exerciseSeries.Level,
                Exercises = exerciseSeries.ExerciseSeriesExercises.Select(exerciseLink =>
                {
                    if (exerciseLink.Exercise == null)
                    {
                        exerciseLink.Exercise = _exerciseRepository.GetById(exerciseLink.ExerciseId);
                    }
                    return exerciseLink.ExerciseId;
                }).ToArray()
            };
        }

        private IEnumerable<ExerciseSeriesDTO> MapExerciseSeriesListToExerciseSeriesDTOList(
            IEnumerable<ExerciseSeries> exerciseSeriesList)
        {
            return exerciseSeriesList.Select(exerciseSeries => new ExerciseSeriesDTO
            {
                Id = exerciseSeries.Id,
                Name = exerciseSeries.Name,
                Code = exerciseSeries.Code,
                Level = exerciseSeries.Level,
                Exercises = exerciseSeries.ExerciseSeriesExercises.Select(exerciseLink =>
                {
                    if (exerciseLink.Exercise == null)
                    {
                        exerciseLink.Exercise = _exerciseRepository.GetById(exerciseLink.ExerciseId);
                    }
                    return exerciseLink.ExerciseId;
                }).ToArray()
            }).ToList();
        }
        
    }
}