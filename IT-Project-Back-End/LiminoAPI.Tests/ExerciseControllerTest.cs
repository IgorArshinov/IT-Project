using System;
using System.Collections.Generic;
using System.ComponentModel;
using LiminoAPI.Business;
using LiminoAPI.Business.Services;
using LiminoAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LiminoAPI.Tests
{
    public class ExerciseControllerTest
    {
        private readonly Mock<IExerciseService> _exerciseServiceMock;
        private readonly ExerciseController _controller;
        private readonly IEnumerable<ExerciseDTO> _exercises;
        
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
        static readonly List<AnswerDTO> AnswersDTOs2 = new List<AnswerDTO> {AnswerDTO4,AnswerDTO5,AnswerDTO6};

        public ExerciseControllerTest()
        {
            _exerciseServiceMock = new Mock<IExerciseService>();
            _controller = new ExerciseController(_exerciseServiceMock.Object);

            _exercises = new List<ExerciseDTO>{_exerciseDTO1, _exerciseDTO2, _exerciseDTO3};
        }
        
        [Fact]
        private void MethodGetExercisesReturnsAllExercises()
        {
            //Setup service Mock
            _exerciseServiceMock.Setup(service => service.GetAll()).Returns(_exercises);

            //Check if controller returns correct response code
            var actionResult = _controller.GetExercises(1);
            Assert.IsType<OkObjectResult>(actionResult);
        }
        
        [Fact]
        private void GetExerciseReturnsNothingForOtherCategories()
        {
            _exerciseServiceMock.Setup(service => service.GetAllExercisesByTypeAndCategory("abcd", 1)).Throws<InvalidEnumArgumentException>();

            var actionResult = _controller.GetExercises(1, "abcd");

            Assert.IsType<BadRequestObjectResult>(actionResult);
        }
        [Fact]
        private void MethodGetExerciseByIdReturnsCorrectExercise()
        {
                //Setup service Mock
                _exerciseServiceMock.Setup(service => service.GetById(1)).Returns(_exerciseDTO1);

                //Check if controller returns correct response code
                var actionResult = _controller.GetExerciseById(1);
                Assert.IsType<OkObjectResult>(actionResult);

                //Check if response body is as expected
                var result = (OkObjectResult) actionResult;
                var responseObject = (ResponseObject) result.Value;
                Assert.Equal(_exerciseDTO1 , responseObject.Data);
        }
        
        [Fact]
        private void ThrowsBadRequestWhenExerciseIdNotExists()
        {
            //Setup service Mock
            _exerciseServiceMock.Setup(service => service.GetById(5555)).Throws(new Exception());

            //Check if controller returns correct response code
            var actionResult = _controller.GetExerciseById(5555);
            var result = (BadRequestObjectResult) actionResult;
            var statusCode = result.StatusCode;
            Assert.Equal(400, statusCode);
        }
        
        [Fact]
        private void MethodPostExerciseAddsExerciseInRepo()
        {
            //Setup repo Mock
            _exerciseServiceMock.Setup(service => service.Add(_exerciseDTO1));
            ResponseObject response = new ResponseObject {Data = _exerciseDTO1};

            //Check if controller return Ok-response
            var actionResult = _controller.PostExercise(response);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(_exerciseDTO1, response.Data);

            //Check if Add-method is called in controller
            _exerciseServiceMock.Verify(service => service.Add(_exerciseDTO1), Times.Once);
        }
        
        [Fact]
        private void MethodPostExerciseThrowsExceptionWhenModelInvalid()
        {
            _controller.ModelState.AddModelError("fakeError", "fakeError");

            var response = (BadRequestObjectResult) _controller.PostExercise(new ResponseObject());
            var statusCode = response.StatusCode;

            Assert.Equal(400, statusCode);
        }
        
        [Fact]
        private void MethodPostExerciseThrowsBadRequestWhenVideoIsNull()
        {
            var response = _controller.PostExercise(null);
            var result = (BadRequestResult) response;
            var statusCode = result.StatusCode;

            Assert.Equal(400, statusCode);
        }
        
        [Fact]
        private void MethodDeleteExerciseDeletesVideoFromRepo()
        {
            //Setup repo mock
            _exerciseServiceMock.Setup(service => service.GetById(3)).Returns(_exerciseDTO1);
            _exerciseServiceMock.Setup(service => service.Delete(1));

            //Check if correct response is returned
            var actionResult = _controller.DeleteExercise(1);
            Assert.IsType<OkResult>(actionResult);

            //Check if Delete method is called in controller
            _exerciseServiceMock.Verify(service => service.Delete(1), Times.Once);
        }
        
        [Fact]
        private void MethodDeleteExerciseThrowsExceptionWhenInvalidId()
        {
            //Setup service mock
            _exerciseServiceMock.Setup(service => service.GetById(1)).Throws(new NullReferenceException());
            _exerciseServiceMock.Setup(service => service.Delete(1)).Throws(new NullReferenceException());

            //Check for correct response
            var actionResult = _controller.DeleteExercise(1);
            Assert.IsType<BadRequestObjectResult>(actionResult);

            var response = (BadRequestObjectResult) _controller.DeleteExercise(1);
            var statusCode = response.StatusCode;
            Assert.Equal(400, statusCode);
        }

        [Fact]
        private void MethodPutUpdatesExercise()
        {
            //Setup repo Mock
            _exerciseServiceMock.Setup(service => service.Put(_exerciseDTO1));
            ResponseObject response = new ResponseObject {Data = _exerciseDTO1};

            //Check if controller return Ok-response
            var actionResult = _controller.UpdateExercise(response);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(_exerciseDTO1, response.Data);

            //Check if Add-method is called in controller
            _exerciseServiceMock.Verify(service => service.Put(_exerciseDTO1), Times.Once);
        }
    }
}