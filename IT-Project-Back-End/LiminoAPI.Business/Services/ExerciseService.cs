using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;

namespace LiminoAPI.Business.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IBaseRepository<Exercise> _repository;

        public ExerciseService(IBaseRepository<Exercise> repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<ExerciseDTO> GetAll()
        {
            var exercises = _repository.GetAll();
            return MapExerciseListToExerciseDTOList(exercises);
        }

        public IEnumerable<ExerciseDTO> GetAllForCategoryId(long? categoryId)
        {
            return MapExerciseListToExerciseDTOList(categoryId == null
                ? _repository.GetAll()
                : _repository.GetAllWhere(exercise => exercise.CategoryId.Equals(categoryId)));
        }
        
        public IEnumerable<ExerciseDTO> GetAllExercisesByTypeAndCategory(string type, long? categoryId)
        {
            switch (type.ToLower())
            {
                case "collage":
                case "true or false":
                case "multiple choice":
                    return MapExerciseListToExerciseDTOList(categoryId != null
                        ? _repository.GetAllWhere(exercise =>
                            exercise.Type.ToLower().Equals(type.ToLower()) && exercise.CategoryId.Equals(categoryId))
                        : _repository.GetAllWhere(exercise => exercise.Type.ToLower().Equals(type.ToLower())));
                default:
                    throw new InvalidEnumArgumentException(type + " is not known type");
            }
        }

        public ExerciseDTO GetById(long id)
        {
            Exercise exercise = _repository.GetById(id);
            if (exercise == null)
            {
                throw new Exception();
            }
            return  MapExerciseToExerciseDTO(exercise);
        }

        public long Add(ExerciseDTO exerciseDTO)
        {
            return _repository.Add(MapExerciseDTOToExercise(exerciseDTO));
        }

        public void Delete(long id)
        {
            _repository.Delete(_repository.GetById(id));
        }

        public void Put(ExerciseDTO exerciseDTO)
        {
            var exercise = MapExerciseDTOToExercise(exerciseDTO);
            _repository.Update(exercise);
        }

        private static IEnumerable<ExerciseDTO> MapExerciseListToExerciseDTOList(IEnumerable<Exercise> exercises)
        {
            return exercises.Select(exercise => new ExerciseDTO
            {
                Id = exercise.Id,
                Type = exercise.Type,
                Title = exercise.Title,
                CategoryId = exercise.CategoryId,
                QuestionUrl = exercise.QuestionUrl,
                ImageUrl = exercise.ImageUrl,
                VideoUrl = exercise.VideoUrl,
                Level = exercise.Level,
                Answers = MapAnswersListToAnswerDTOList(exercise.Answers)
            }).ToList();
        }

        private static ExerciseDTO MapExerciseToExerciseDTO(Exercise exercise)
        {
            return new ExerciseDTO
            {
                Id = exercise.Id,
                Type = exercise.Type,
                Title = exercise.Title,
                CategoryId = exercise.CategoryId,
                QuestionUrl = exercise.QuestionUrl,
                VideoUrl = exercise.VideoUrl,
                ImageUrl = exercise.ImageUrl,
                Level = exercise.Level,
                Answers = MapAnswersListToAnswerDTOList(exercise.Answers)
            };
        }

        private static Exercise MapExerciseDTOToExercise(ExerciseDTO exerciseDTO)
        {
            return new Exercise
            {
                Id = exerciseDTO.Id,
                Title = exerciseDTO.Title,
                Type = exerciseDTO.Type,
                ImageUrl = exerciseDTO.ImageUrl,
                CategoryId = exerciseDTO.CategoryId,
                QuestionUrl = exerciseDTO.QuestionUrl,
                VideoUrl = exerciseDTO.VideoUrl,
                Level = exerciseDTO.Level,
                Answers = MapAnswerDTOListToAnswerList(exerciseDTO.Answers)
            };
        }

        private static List<AnswerDTO> MapAnswersListToAnswerDTOList(IEnumerable<Answer> answers)
        {
            
            return answers?.Select(answer => new AnswerDTO
            {
                AudioUrl = answer.AudioUrl,
                ImageUrl = answer.ImageUrl,
                IsCorrect = answer.IsCorrect
            }).ToList();
        }

        private static List<Answer> MapAnswerDTOListToAnswerList(IEnumerable<AnswerDTO> answers)
        {
            return answers?.Select(answer => new Answer
            {
                AudioUrl = answer.AudioUrl,
                ImageUrl = answer.ImageUrl,
                IsCorrect = answer.IsCorrect
            }).ToList();
        }
    }
}