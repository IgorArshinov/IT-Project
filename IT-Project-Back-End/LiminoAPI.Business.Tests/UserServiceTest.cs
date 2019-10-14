using System;
using System.Collections.Generic;
using LiminoAPI.Business.Services;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;
using Moq;
using Xunit;

namespace LiminoAPI.Business.Tests
{
    public class UserServiceTest
    {
        private readonly Mock<IBaseRepository<User>> _repository;
        private readonly UserService _service;

        private readonly IEnumerable<User> _users;

        private readonly User _user1 = new User
        {
            Id = 1,
            Name = null,
            PasswordHash = new byte[64],
            PasswordSalt = new byte[128],
            Username = "testUser"
        };
        private readonly User _user2 = new User
        {
            Id = 2,
            Name = null,
            PasswordHash = new byte[64],
            PasswordSalt = new byte[128],
            Username = "testUser2"
        };

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

        public UserServiceTest()
        {
            _repository = new Mock<IBaseRepository<User>>();
            _service = new UserService(_repository.Object);

            _users = new List<User> {_user1, _user2};
            _userDtos = new List<UserDTO> {_userDto1, _userDto2};
        }

        [Fact]
        private void MethodGetAllUsersReturnsAllUsers()
        {
            _repository.Setup(repo => repo.GetAll()).Returns(_users);

            var actionResult = _service.GetAll();
            Assert.Equal(_userDtos, actionResult);
        }

        [Fact]
        private void MethodGetByIdReturnsCorrectUser()
        {
            _repository.Setup(repo => repo.GetById(1)).Returns(_user1);

            var actionResult = _service.GetById(1);
            Assert.Equal(_userDto1, actionResult);
        }

        [Fact]
        private void MethodGetByIdThrowsExceptionWhenIdIsInvalid()
        {
            _repository.Setup(repo => repo.GetById(1)).Returns(_user1);

            Assert.Throws<NullReferenceException>(() => _service.GetById(5555));
        }

        [Fact]
        private void MethodCreateAddsUserAndReturnsCorrectResponse()
        {
            _repository.Setup(repo => repo.Add(_user1));
            _repository.Setup(repo => repo.GetAll()).Returns(_users);

            Assert.Throws<Exception>(() => _service.Create(_userDto1));
        }

        [Fact]
        private void MethodDeleteThrowsExceptionWhenInvalid()
        {
            _repository.Setup(repo => repo.Delete(_user1)).Throws(new Exception());
            _repository.Setup(repo => repo.GetById(1)).Returns(_user1);
            
            Assert.Throws<Exception>(() => _service.Delete(1));
        }

        [Fact]
        private void MethodDeleteReturnsCorrectResponse()
        {
            _repository.Setup(repo => repo.Delete(_user1));
            _repository.Setup(repo => repo.GetById(1)).Returns(_user1);
            
            _service.Delete(1);
            _repository.Verify(repo => repo.Delete(_user1), Times.Once);
        }

        [Fact]
        private void MethodPutReturnsCorrectResponse()
        {
            _repository.Setup(repo => repo.Update(_user1));
            _repository.Setup(repo => repo.GetById(1)).Returns(_user1);
            
            _service.Update(1, _userDto1);
            _repository.Verify(repo => repo.Update(_user1), Times.Once);
        }
    }
}