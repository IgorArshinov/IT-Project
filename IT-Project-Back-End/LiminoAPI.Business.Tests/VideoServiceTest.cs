using System;
using System.Collections.Generic;
using LiminoAPI.Business.Services;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;
using Moq;
using Xunit;

namespace LiminoAPI.Business.Tests
{
    public class VideoServiceTest
    {
        private readonly Mock<IBaseRepository<Video>> _repository;
        private readonly VideoService _service;

        private readonly IEnumerable<Video> _videos;

        private readonly Video _video1 = new Video
        {
            CategoryId = 1,
            Id = 1,
            Name = "Video van een banaan",
            VideoUrl = "VideoUrl1"
        };

        private readonly Video _video2 = new Video
        {
            CategoryId = 1,
            Id = 4,
            Name = "Video van een appel",
            VideoUrl = "VideoUrl2"
        };

        private readonly Video _video3 = new Video
        {
            CategoryId = 2,
            Id = 2,
            Name = "Video van een bus",
            VideoUrl = "VideoUrl2"
        };

        private readonly Video _video4 = new Video
        {
            CategoryId = 3,
            Id = 3,
            Name = "Video van een glas water",
            VideoUrl = "VideoUrl3"
        };

        private readonly IEnumerable<VideoDTO> _videoDTOs;

        private readonly VideoDTO _videoDto1 = new VideoDTO
        {
            CategoryId = 1,
            Id = 1,
            Name = "Video van een banaan",
            VideoUrl = "VideoUrl1"
        };

        private readonly VideoDTO _videoDto2 = new VideoDTO
        {
            CategoryId = 1,
            Id = 4,
            Name = "Video van een appel",
            VideoUrl = "VideoUrl2"
        };

        private readonly VideoDTO _videoDto3 = new VideoDTO
        {
            CategoryId = 2,
            Id = 2,
            Name = "Video van een bus",
            VideoUrl = "VideoUrl2"
        };

        private readonly VideoDTO _videoDto4 = new VideoDTO
        {
            CategoryId = 3,
            Id = 3,
            Name = "Video van een glas water",
            VideoUrl = "VideoUrl3"
        };

        public VideoServiceTest()
        {
            _repository = new Mock<IBaseRepository<Video>>();
            _service = new VideoService(_repository.Object);

            _videos = new List<Video> {_video1, _video2, _video3, _video4};
            _videoDTOs = new List<VideoDTO> {_videoDto1, _videoDto2, _videoDto3, _videoDto4};
        }

        [Fact]
        private void MethodGetAllReturnsListOfVideoDto()
        {
            //Setup repo mock
            _repository.Setup(repo => repo.GetAll()).Returns(_videos);

            //check if results are equal
            var actionResult = _service.GetAll();
            Assert.Equal(_videoDTOs, actionResult);
        }

        [Fact]
        private void MethodGetAllByCategoryIdReturnsListOfVideoDto()
        {
            //Setup repo mock
            _repository.Setup(repo => repo.GetAllWhere(It.IsAny<Func<Video, bool>>())).Returns(_videos);

            //check if results are equal
            var actionResult = _service.GetAllByCategoryId(1);
            Assert.Equal(_videoDTOs, actionResult);
        }

        [Fact]
        private void MethodGetByIdReturnsCorrectVideo()
        {
            //Setup repo mock
            _repository.Setup(repo => repo.GetById(1)).Returns(_video1);

            //check if results are equal
            var actionResult = _service.GetById(1);
            Assert.Equal(_videoDto1, actionResult);
        }

        [Fact]
        private void MethodGetByIdThrowsExceptionWhenIdIsInvalid()
        {
            //Setup repo mock
            _repository.Setup(repo => repo.GetById(1)).Returns(_video1);

            Assert.Throws<Exception>(() => _service.GetById(5555));
        }

        [Fact]
        private void MethodAddReturnsCorrectResponse()
        {
            //Setup repo mock
            _repository.Setup(repo => repo.Add(_video1));

            //check correct response
            _service.Add(_videoDto1);

            _repository.Verify(repo => repo.Add(_video1), Times.Once);
        }

        [Fact]
        private void MethodDeleteThrowsExceptionWhenInvalid()
        {
            _repository.Setup(repo => repo.Delete(_video1)).Throws(new Exception());

            Assert.Throws<Exception>(() => _service.Delete(_videoDto1));
        }

        [Fact]
        private void MethodDeleteCallsDeleteInRepo()
        {
            //Setup repo
            _repository.Setup(repo => repo.Delete(_video1));

            //check Delete has called in repo
            _service.Delete(_videoDto1);
            _repository.Verify(repo => repo.Delete(_video1), Times.Once);
        }
    }
}