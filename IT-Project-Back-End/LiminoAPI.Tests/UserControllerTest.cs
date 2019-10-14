using System;
using System.Collections.Generic;
using LiminoAPI.Business;
using LiminoAPI.Business.Services;
using LiminoAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LiminoAPI.Tests
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserController _controller;
      
        private readonly IEnumerable<UserDTO> _userDtos;
        private readonly UserDTO _userDto1 = new UserDTO
        {
            Id = 1,
            Username = "testUser",
            Password = "password"
        };
        private readonly UserDTO _userDto2 = new UserDTO
        {
            Id = 2,
            Username = "testUser2",
            Password = "password"
        };

        public UserControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
            _controller = new UserController(_userServiceMock.Object);
            _userDtos = new List<UserDTO>{_userDto1, _userDto2};
        }

        [Fact]
        private void MethodGetUsersReturnsAllUsers()
        {
            _userServiceMock.Setup(service => service.GetAll()).Returns(_userDtos);

            var actionResult = _controller.GetAll();
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        private void MethodGetUserByIdReturnsCorrectUser()
        {
            _userServiceMock.Setup(service => service.GetById(1)).Returns(_userDto1);

            var actionResult = _controller.GetById(1);
            Assert.IsType<OkObjectResult>(actionResult);

            var result = (OkObjectResult) actionResult;
            var responseObject = (ResponseObject) result.Value;
            Assert.Equal(_userDto1, responseObject.Data);
        }

        [Fact]
        private void ThrowsBadRequestWhenUserIdNotExists()
        {
            _userServiceMock.Setup(service => service.GetById(5555)).Throws(new Exception());

            var actionResult = _controller.GetById(5555);
            var result = (BadRequestObjectResult) actionResult;
            var statusCode = result.StatusCode;
            Assert.Equal(400, statusCode);
        }
        [Fact]
        private void MethodDeleteUserDeletesVideoFromRepo()
        {
            _userServiceMock.Setup(repo => repo.GetById(1)).Returns(_userDto1);
            _userServiceMock.Setup(repo => repo.Delete(1));

            var actionResult = _controller.Delete(1);
            Assert.IsType<OkResult>(actionResult);

            _userServiceMock.Verify(repo => repo.Delete(1), Times.Once);
        }

        [Fact]
        private void MethodDeleteUserThrowsExceptionWhenInvalidId()
        {
            _userServiceMock.Setup(repo => repo.GetById(1)).Throws(new NullReferenceException());
            _userServiceMock.Setup(repo => repo.Delete(1)).Throws(new NullReferenceException());

            var actionResult = _controller.Delete(1);
            Assert.IsType<BadRequestObjectResult>(actionResult);

            var response = (BadRequestObjectResult) _controller.Delete(1);
            var statusCode = response.StatusCode;
            Assert.Equal(400, statusCode);
        }
        [Fact]
        private void MethodPutUpdatesUser()
        {
            //Setup repo Mock
            _userServiceMock.Setup(service => service.Update(1,_userDto1));
            ResponseObject response = new ResponseObject {Data = _userDto1};

            //Check if controller return Ok-response
            var actionResult = _controller.Update(1,response);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(_userDto1, response.Data);

            //Check if Add-method is called in controller
            _userServiceMock.Verify(service => service.Update(1,_userDto1), Times.Once);
        }
        [Fact]
        private void MethodUpdateUserThrowsExceptionWhenInvalidId()
        {
            _userServiceMock.Setup(repo => repo.GetById(1)).Throws(new NullReferenceException());
            _userServiceMock.Setup(repo => repo.Update(1, _userDto1)).Throws(new NullReferenceException());
            ResponseObject data = new ResponseObject {Data = _userDto1};

            var actionResult = _controller.Update(1, data);
            Assert.IsType<BadRequestObjectResult>(actionResult);

            var response = (BadRequestObjectResult) _controller.Update(1,data);
            var statusCode = response.StatusCode;
            Assert.Equal(400, statusCode);
        }
    }
}