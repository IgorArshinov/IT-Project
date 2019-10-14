using System;
using System.Collections.Generic;
using LiminoAPI.Business.Services;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;
using Moq;
using Xunit;

namespace LiminoAPI.Business.Tests
{
    public class ExerciseSeriesServiceTest
    {
        private readonly Mock<IBaseRepository<Exercise>> _exerciseRepository;
        private readonly Mock<IExerciseSeriesRepository> _repository;
        private readonly ExerciseSeriesService _service;
        
        //Answers
        private static readonly Answer Answer1 = new Answer
            {Id = 1, ExerciseId = 1, AudioUrl = "AudioUrl1", ImageUrl = "ImgUrl1", IsCorrect = false};
        private static readonly Answer Answer2 = new Answer
            {Id = 2, ExerciseId = 1, AudioUrl = "AudioUrl2", ImageUrl = "ImgUrl2", IsCorrect = false};
        private static readonly Answer Answer3 = new Answer
            {Id = 3, ExerciseId = 1, AudioUrl = "AudioUrl3", ImageUrl = "ImgUrl3", IsCorrect = true};
        private static readonly List<Answer> Answers1 = new List<Answer> {Answer1, Answer2, Answer3};
        
        //Exercises
        private static readonly Exercise Exercise1 = new Exercise
        {
            Id = 1,
            Type = "Collage",
            CategoryId = 1,
            Name = "First Question",
            QuestionUrl = "questionUrl",
            VideoUrl = "videoUrl",
            Answers = Answers1
        };
        private static readonly Exercise Exercise2 = new Exercise
        {
            Id = 1,
            Type = "Collage",
            CategoryId = 1,
            Name = "First Question",
            QuestionUrl = "questionUrl",
            VideoUrl = "videoUrl",
            Answers = Answers1
        };
        private static readonly Exercise Exercise3 = new Exercise
        {
            Id = 1,
            Type = "Collage",
            CategoryId = 1,
            Name = "First Question",
            QuestionUrl = "questionUrl",
            VideoUrl = "videoUrl",
            Answers = Answers1
        };
           
        //ExerciseSeries
        private static IEnumerable<ExerciseSeries> _exerciseSeries;

        private readonly ExerciseSeries _exerciseSeries1 = new ExerciseSeries
        {
            Name = "first series",
            Id = 1,
            Level = "Gemakkelijk",
            Code = 111,
            ExerciseSeriesExercises = new List<ExerciseSeriesExercises>()
        };
        private readonly ExerciseSeries _exerciseSeries2 = new ExerciseSeries
        {
            Name = "second series",
            Id = 2,
            Code = 2222,
            Level = "Moeilijk",
            ExerciseSeriesExercises = new List<ExerciseSeriesExercises>()
        };
        

        //ExerciseSeriesDTO
        private static IEnumerable<ExerciseSeriesDTO> _exerciseSeriesDtos;

/*
        private readonly ExerciseSeriesDTO _exerciseSeriesDTO1 = new ExerciseSeriesDTO
        {
            Name = "first series",
            Id = 1,
            Level = "Gemakkelijk",
            Code = 1111
        };
        private readonly ExerciseSeriesDTO _exerciseSeriesDTO2 = new ExerciseSeriesDTO
        {
            Name = "second series",
            Id = 2,
            Code = 2222,
            Level = "Moeilijk"
        };
           
        public ExerciseSeriesServiceTest()
        {
            _repository = new Mock<IExerciseSeriesRepository>();
            _exerciseRepository = new Mock<IBaseRepository<Exercise>>();
            
            _service = new ExerciseSeriesService(_repository.Object, _exerciseRepository.Object);

            _exerciseSeries = new List<ExerciseSeries> {_exerciseSeries1, _exerciseSeries2};
            _exerciseSeriesDtos = new List<ExerciseSeriesDTO>{_exerciseSeriesDTO1, _exerciseSeriesDTO2};
        }

        [Fact]
        private void MethodGetAllReturnsListOfExerciseSeries()
        {
            _repository.Setup(repo => repo.GetAll()).Returns(_exerciseSeries);
            _exerciseRepository.Setup(repo => repo.GetById(1)).Returns(Exercise1);
            _exerciseRepository.Setup(repo => repo.GetById(2)).Returns(Exercise2);
            _exerciseRepository.Setup(repo => repo.GetById(3)).Returns(Exercise3);
            
            var actionResult = _service.GetAllSeries();
            Assert.Equal(_exerciseSeriesDtos, actionResult);
        }

        [Fact]
        private void MethodGetByIdReturnsCorrectExerciseSeries()
        {
            _repository.Setup(repo => repo.GetById(1)).Returns(_exerciseSeries1);
            var actionResult = _service.GetById(1);
            Assert.Equal(_exerciseSeriesDTO1, actionResult);
        }

        [Fact]
        private void MethodGetByIdThrowsExceptionWhenIdIsInvalid()
        {
            _repository.Setup(repo => repo.GetById(1)).Returns(_exerciseSeries1);
            Assert.Throws<NullReferenceException>(() => _service.GetById(5555));
        }

        [Fact]
        private void MethodDeleteThrowsExceptionWhenInvalid()
        {
            _repository.Setup(repo => repo.GetById(5555)).Returns(_exerciseSeries1);
            _repository.Setup(repo => repo.Delete(1)).Throws(new Exception());
            
            Assert.Throws<Exception>(() => _service.Delete(1));
        }

        [Fact]
        private void MethodDeleteCallsDeleteInRepo()
        {
            _repository.Setup(repo => repo.Delete(1));
            _repository.Setup(repo => repo.GetById(1)).Returns(_exerciseSeries1);

            //check Delete has called in repo
            _service.Delete(1);
            _repository.Verify(repo => repo.Delete(1), Times.Once);
        }
        
        */
    }
    
    
}