using System;
using System.Collections.Generic;
using LiminoAPI.Business;
using LiminoAPI.Business.Services;
using LiminoAPI.Controllers;
using LiminoAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LiminoAPI.Tests
{
    public class ExerciseSeriesControllerTest
    {
        private readonly Mock<IExerciseSeriesService> _exerciseSeriesServiceMock;
        private readonly ExerciseSeriesController _controller;
        private readonly IEnumerable<ExerciseSeriesDTO> _exerciseSeries;
       

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
        private static readonly IEnumerable<ExerciseDTO> ExercisesDTOList = new List<ExerciseDTO>
            {ExerciseDTO1, ExerciseDTO2};
        
        private static readonly ExerciseDTO ExerciseDTO1 = new ExerciseDTO
        {
            Type = "Collage",
            CategoryId = 1,
            QuestionUrl = "questionUrl",
            VideoUrl = "videoUrl",
            Answers = AnswersDTOs1
        };
        private static readonly ExerciseDTO ExerciseDTO2 = new ExerciseDTO
        {
            Type = "True Or False",
            CategoryId = 2,
            QuestionUrl = "questionUrl2",
            VideoUrl = "videoUrl2",
            Answers = AnswersDTOs2
        };
        private static readonly ExerciseSeriesDTO ExerciseSeriesDTO1 = new ExerciseSeriesDTO
        {
            Id = 1,
            Name = "exerciseSeries1"
        };
        
        private static readonly ExerciseSeriesDTO ExerciseSeriesDTO2 = new ExerciseSeriesDTO
        {
            Id = 2,
            Name = "exerciseSeries2"
        };
        
        private static readonly Answer Answer1 = new Answer
            {AudioUrl = "AudioUrl1", ImageUrl = "ImgUrl1", IsCorrect = false};
        private static readonly Answer Answer2 = new Answer
            {AudioUrl = "AudioUrl2", ImageUrl = "ImgUrl2", IsCorrect = false};
        private static readonly Answer Answer3 = new Answer
            {AudioUrl = "AudioUrl3", ImageUrl = "ImgUrl3", IsCorrect = true};
        private static readonly List<Answer> Answers1 = new List<Answer> {Answer1,Answer2,Answer3};
        
        private static readonly Answer Answer4 = new Answer
            { AudioUrl = "AudioUrl1", ImageUrl = "ImgUrl1", IsCorrect = false};
        private static readonly Answer Answer5 = new Answer
            {AudioUrl = "AudioUrl2", ImageUrl = "ImgUrl2", IsCorrect = false};
        private static readonly Answer Answer6 = new Answer
            {AudioUrl = "AudioUrl3", ImageUrl = "ImgUrl3", IsCorrect = true};
        private static readonly List<Answer> Answers2 = new List<Answer> {Answer4,Answer5,Answer6};

        private static readonly Exercise Exercise1 = new Exercise
        {
            Type = "Collage",
            CategoryId = 1,
            QuestionUrl = "questionUrl",
            VideoUrl = "videoUrl",
            Answers = Answers1
        };
        private static readonly Exercise Exercise2 = new Exercise
        {
            Type = "True Or False",
            CategoryId = 2,
            QuestionUrl = "questionUrl2",
            VideoUrl = "videoUrl2",
            Answers = Answers2
        };
        private static readonly IEnumerable<Exercise> ExercisesList = new List<Exercise>{Exercise1, Exercise2};
        private static readonly ExerciseSeries ExerciseSeries1 = new ExerciseSeries
        {
            Id = 1,
            Name = "exerciseSeries1"
        };
        
        
        public ExerciseSeriesControllerTest()
        {
            _exerciseSeriesServiceMock = new Mock<IExerciseSeriesService>();
            _controller = new ExerciseSeriesController(_exerciseSeriesServiceMock.Object);
            
            _exerciseSeries = new List<ExerciseSeriesDTO>
            {
                ExerciseSeriesDTO1, ExerciseSeriesDTO2
            };
        }

        [Fact]
        private void MethodGetAllExerciseSeriesReturnsAllExerciseSeries()
        {
            _exerciseSeriesServiceMock.Setup(service => service.GetAllSeries()).Returns(_exerciseSeries);

            var actionResult = _controller.GetExerciseSeries();
            Assert.IsType<OkObjectResult>(actionResult);
        }
        /*
        [Fact]
        private void MethodGetExerciseSeriesByIdReturnsCorrectExercise()
        {
            _exerciseSeriesServiceMock.Setup(service => service.GetById(1)).Returns(ExerciseSeriesDTO1);

            var actionResult = _controller.GetExerciseSeriesById(1);
            Assert.IsType<OkObjectResult>(actionResult);

            var result = (OkObjectResult) actionResult;
            var responseObject = (ResponseObject) result.Value;
            Assert.Equal(ExerciseSeriesDTO1, responseObject.Data);
        }
        [Fact]
        private void ThrowsBadRequestWhenExerciseIdNotExists()
        {
            _exerciseSeriesServiceMock.Setup(service => service.GetById(5555)).Throws(new Exception());

            var actionResult = _controller.GetExerciseSeriesById(5555);
            var result = (BadRequestObjectResult) actionResult;
            var statusCode = result.StatusCode;
            Assert.Equal(400, statusCode);
        }
        */
        [Fact]
        private void MethodPostExerciseSeriesTriggersServiceMethod()
        {
            _exerciseSeriesServiceMock.Setup(service => service.Add(ExerciseSeriesDTO1));
            var response = new ResponseObject {Data = ExerciseSeriesDTO1};

            var actionResult = _controller.PostExerciseSeries(response);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(ExerciseSeriesDTO1, response.Data);
            _exerciseSeriesServiceMock.Verify(service => service.Add(ExerciseSeriesDTO1), Times.Once);

        }
        [Fact]
        private void MethodPostExerciseSeriesThrowsExceptionWhenModelIsInvalid()
        {
            _controller.ModelState.AddModelError("error", "error");
            var response = (BadRequestObjectResult) _controller.PostExerciseSeries(new ResponseObject());
            var statusCode = response.StatusCode;
            
            Assert.Equal(400, statusCode);
        }
        [Fact]
        private void MethodPostExerciseSeriesReturnsBadRequestWhenSeriesIsNull()
        {
            var response = _controller.PostExerciseSeries(null);
            var result = (BadRequestResult) response;
            var statusCode = result.StatusCode;
            
            Assert.Equal(400, statusCode);
        }
        /*
        [Fact]
        private void MethodDeleteExerciseSeriesCallsServiceMethod()
        {
            _exerciseSeriesServiceMock.Setup(service => service.GetById(1)).Returns(ExerciseSeriesDTO1);
            _exerciseSeriesServiceMock.Setup(service => service.Delete(1));
            var response = new ResponseObject {Data = ExerciseSeries1};
            
            var actionResult = _controller.DeleteExerciseSeries(1);
            Assert.IsType<OkResult>(actionResult);
            
            _exerciseSeriesServiceMock.Verify(service => service.Delete(1), Times.Once);
        }
        [Fact]
        private void MethodDeleteExerciseSeriesThrowsExceptionWhenInvalid()
        {
            _exerciseSeriesServiceMock.Setup(service => service.GetById(1)).Throws(new NullReferenceException());
            _exerciseSeriesServiceMock.Setup(service => service.Delete(1))
                .Throws(new NullReferenceException());
            
            var response = new ResponseObject {Data = ExerciseSeries1};
            var actionResult = _controller.DeleteExerciseSeries(1);
            Assert.IsType<BadRequestObjectResult>(actionResult);

            var responseCode = (BadRequestObjectResult) _controller.DeleteExerciseSeries(1);
            var statusCode = responseCode.StatusCode;
            Assert.Equal(400, statusCode);
        }

        [Fact]
        private void MethodPutUpdatesExercise()
        {
            _exerciseSeriesServiceMock.Setup(service => service.Update(ExerciseSeriesDTO1));
            var response = new ResponseObject {Data = ExerciseSeriesDTO1};

            var actionResult = _controller.UpdateExerciseSeries(response);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(ExerciseSeriesDTO1, response.Data);
            
            _exerciseSeriesServiceMock.Verify(service => service.Update(ExerciseSeriesDTO1), Times.Once);
        }
        */
        
    }
}