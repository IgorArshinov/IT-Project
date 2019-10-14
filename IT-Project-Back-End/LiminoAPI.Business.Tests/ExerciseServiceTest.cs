using System;
using System.Collections.Generic;
using System.ComponentModel;
using LiminoAPI.Business.Services;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;
using Moq;
using Xunit;

namespace LiminoAPI.Business.Tests
{
    public class ExerciseServiceTest
    {
        private readonly Mock<IBaseRepository<Exercise>> _repository;
        private readonly ExerciseService _service;

        private readonly IEnumerable<Exercise> _exercises;
        private readonly IEnumerable<ExerciseDTO> _exerciseDtos;

        private readonly Exercise _exercise1 = new Exercise
        {
            Id = 1,
            Type = "Collage",
            CategoryId = 1,
            Name = "First Question",
            QuestionUrl = "questionUrl",
            VideoUrl = "videoUrl",
            Answers = Answers1
        };
        private readonly Exercise _exercise2 = new Exercise
        {
            Id = 2,
            Type = "True Or False",
            CategoryId = 2,
            Name = "Second Question",
            QuestionUrl = "questionUrl2",
            VideoUrl = "videoUrl2",
            Answers = Answers2
        };
        private readonly Exercise _exercise3 = new Exercise
        {
            Id = 3,
            Type = "Multiple Choice",
            CategoryId = 3,
            Name = "Second Question",
            QuestionUrl = "questionUrl3",
            VideoUrl = "videoUrl3",
            Answers = Answers3
        };

        private readonly ExerciseDTO _exerciseDTO1 = new ExerciseDTO
        {
            Type = "Collage",
            CategoryId = 1,
            QuestionUrl = "questionUrl",
            VideoUrl = "videoUrl",
            Answers = AnswersDTOs1
        };
        private readonly ExerciseDTO _exerciseDTO2 = new ExerciseDTO
        {
            Type = "True Or False",
            CategoryId = 2,
            QuestionUrl = "questionUrl2",
            VideoUrl = "videoUrl2",
            Answers = AnswersDTOs2
        };
        private readonly ExerciseDTO _exerciseDTO3 = new ExerciseDTO
        {
            Type = "Multiple Choice",
            CategoryId = 3,

            QuestionUrl = "questionUrl3",
            VideoUrl = "videoUrl3"
        };
         
        private static readonly Answer Answer1 = new Answer
            {Id = 1, ExerciseId = 1, AudioUrl = "AudioUrl1", ImageUrl = "ImgUrl1", IsCorrect = false};
        private static readonly Answer Answer2 = new Answer
            {Id = 2, ExerciseId = 1, AudioUrl = "AudioUrl2", ImageUrl = "ImgUrl2", IsCorrect = false};
        private static readonly Answer Answer3 = new Answer
            {Id = 3, ExerciseId = 1, AudioUrl = "AudioUrl3", ImageUrl = "ImgUrl3", IsCorrect = true};
        private static readonly List<Answer> Answers1 = new List<Answer> {Answer1, Answer2, Answer3};
        private static readonly Answer Answer4 = new Answer
            {Id = 4, ExerciseId = 2, AudioUrl = "AudioUrl1", ImageUrl = "ImgUrl1", IsCorrect = false};
        private static readonly Answer Answer5 = new Answer
            {Id = 5, ExerciseId = 2, AudioUrl = "AudioUrl2", ImageUrl = "ImgUrl2", IsCorrect = false};
        private static readonly Answer Answer6 = new Answer
            {Id = 6, ExerciseId = 2, AudioUrl = "AudioUrl3", ImageUrl = "ImgUrl3", IsCorrect = true};
        static readonly List<Answer> Answers2 = new List<Answer> {Answer4, Answer5, Answer6};
        private static readonly Answer Answer7 = new Answer
            {Id = 7, ExerciseId = 3, AudioUrl = "AudioUrl1", ImageUrl = "ImgUrl1", IsCorrect = false};
        private static readonly Answer Answer8 = new Answer
            {Id = 8, ExerciseId = 3, AudioUrl = "AudioUrl2", ImageUrl = "ImgUrl2", IsCorrect = false};
        private static readonly Answer Answer9 = new Answer
            {Id = 9, ExerciseId = 3, AudioUrl = "AudioUrl3", ImageUrl = "ImgUrl3", IsCorrect = true};
        private static readonly List<Answer> Answers3 = new List<Answer> {Answer7, Answer8, Answer9};
        
        private static readonly AnswerDTO AnswerDTO1 = new AnswerDTO
            {AudioUrl = "AudioUrl1", ImageUrl = "ImgUrl1", IsCorrect = false};
        private static readonly AnswerDTO AnswerDTO2 = new AnswerDTO
            {AudioUrl = "AudioUrl2", ImageUrl = "ImgUrl2", IsCorrect = false};
        private static readonly AnswerDTO AnswerDTO3 = new AnswerDTO
            {AudioUrl = "AudioUrl3", ImageUrl = "ImgUrl3", IsCorrect = true};
        private static readonly List<AnswerDTO> AnswersDTOs1 = new List<AnswerDTO> {AnswerDTO1,AnswerDTO2,AnswerDTO3};
        
        private static readonly AnswerDTO AnswerDTO4 = new AnswerDTO
            { AudioUrl = "AudioUrl1", ImageUrl = "ImgUrl1", IsCorrect = false};
        private static readonly AnswerDTO AnswerDTO5 = new AnswerDTO
            {AudioUrl = "AudioUrl2", ImageUrl = "ImgUrl2", IsCorrect = false};
        private static readonly AnswerDTO AnswerDTO6 = new AnswerDTO
            {AudioUrl = "AudioUrl3", ImageUrl = "ImgUrl3", IsCorrect = true};

        private static readonly List<AnswerDTO> AnswersDTOs2 = new List<AnswerDTO> {AnswerDTO4,AnswerDTO5,AnswerDTO6};

        public ExerciseServiceTest()
        {
            _repository = new Mock<IBaseRepository<Exercise>>();
            _service = new ExerciseService(_repository.Object);

            _exercises = new List<Exercise> {_exercise1, _exercise2, _exercise3};
            _exerciseDtos = new List<ExerciseDTO>{_exerciseDTO1,_exerciseDTO2,_exerciseDTO3};
        }

        [Fact]
        private void MethodGetAllReturnsListOfExercise()
        {
            _repository.Setup(repo => repo.GetAll()).Returns(_exercises);
            
            var actionResult = _service.GetAll();
            Assert.Equal(_exerciseDtos, actionResult);
        }

        [Fact]
        private void MethodGetByCategoryIdReturnsCorrectExercises()
        {
            _repository.Setup(repo => repo.GetAllWhere(It.IsAny<Func<Exercise, bool>>())).Returns(_exercises);

            var actionResult = _service.GetAllForCategoryId(1);
            Assert.Equal(_exerciseDtos, actionResult);
        }

        [Fact]
        private void MethodGetByIdReturnsCorrectExercise()
        {
            _repository.Setup(repo => repo.GetById(1)).Returns(_exercise1);

            var actionResult = _service.GetById(1);
            Assert.Equal(_exerciseDTO1 , actionResult);
        }
        
        [Fact]
        private void MethodGetByIdThrowsExceptionWhenIdIsInvalid()
        {
            //Setup repo mock
            _repository.Setup(repo => repo.GetById(1)).Returns(_exercise1);

            Assert.Throws<Exception>(() => _service.GetById(5555));
        }

        [Fact]
        private void MethodGetByIdTrowsExceptionWhenIdDoesNotExist()
        {
            _repository.Setup(repo => repo.GetById(5555)).Throws<Exception>();
            Assert.Throws<Exception>(() => _service.GetById(5555));
        }

        [Fact]
        private void MethodAddExerciseReturnsCorrectResponse()
        {
            _repository.Setup(repo => repo.Add(_exercise1));
            _service.Add(_exerciseDTO1);

            _repository.Verify(repo => repo.Add(_exercise1), Times.Once);
        }
        
        [Fact]
        private void MethodDeleteThrowsExceptionWhenInvalid()
        {
            _repository.Setup(repo => repo.GetById(5555)).Returns(_exercise1);
            _repository.Setup(repo => repo.Delete(_exercise1)).Throws(new Exception());

            Assert.Throws<Exception>(() => _service.Delete(5555));
        }
        
        [Fact]
        private void MethodDeleteCallsDeleteInRepo()
        {
            //Setup repo
            _repository.Setup(repo => repo.Delete(_exercise1));
            _repository.Setup(repo => repo.GetById(1)).Returns(_exercise1);

            //check Delete has called in repo
            _service.Delete(1);
            _repository.Verify(repo => repo.Delete(_exercise1), Times.Once);
        }

        [Fact]
        private void MethodPutCallsPutInRepo()
        {
            //Setup repo
            _repository.Setup(repo => repo.Update(_exercise1));

            //check Delete has called in repo
            _service.Put(_exerciseDTO1);
            _repository.Verify(repo => repo.Update(_exercise1), Times.Once);
        }

        [Fact]
        private void MethodGetAllExercisesByTypeAndCategoryReturnsCorrectResponse()
        {
            _repository.Setup(repo => repo.GetAllWhere(It.IsAny<Func<Exercise, bool>>())).Returns(_exercises);

            var actionResult = _service.GetAllExercisesByTypeAndCategory("collage", 1);
            Assert.Equal(_exerciseDtos, actionResult);
        }
        
        [Fact]
        private void MethodGetAllExercisesByTypeAndCategoryReturnsCorrectResponseWithCapitalInType()
        {
            _repository.Setup(repo => repo.GetAllWhere(It.IsAny<Func<Exercise, bool>>())).Returns(_exercises);

            var actionResult = _service.GetAllExercisesByTypeAndCategory("cOllAge", 1);
            Assert.Equal(_exerciseDtos, actionResult);
        }
        [Fact]
        private void MethodGetAllExercisesByTypeAndCategoryReturnsCorrectResponseWithCategoryTypeIsNull()
        {
            _repository.Setup(repo => repo.GetAllWhere(It.IsAny<Func<Exercise, bool>>())).Returns(_exercises);

            var actionResult = _service.GetAllExercisesByTypeAndCategory("cOllAge", null);
            Assert.Equal(_exerciseDtos, actionResult);
        }
        
        [Fact]
        private void MethodGetAllExercisesByTypeAndCategoryThrowsExceptionWhenTypeIsNotKnown()
        {
            _repository.Setup(repo => repo.GetAllWhere(It.IsAny<Func<Exercise, bool>>())).Returns(_exercises);

            Assert.Throws<InvalidEnumArgumentException>(() => _service.GetAllExercisesByTypeAndCategory("Non-existingType", null));
        }
    }
}