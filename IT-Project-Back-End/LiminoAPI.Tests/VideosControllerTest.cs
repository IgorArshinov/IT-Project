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
    public class VideosControllerTest
    {
        private readonly Mock<IVideoService> _videoServiceMock;

        private readonly VideosController _controller;
        private readonly IEnumerable<VideoDTO> _videos;

        private readonly VideoDTO _video1 = new VideoDTO
        {
            CategoryId = 1,
            Id = 1,
            Name = "Video van een banaan",
            VideoUrl = "VideoUrl1"
        };

        private readonly VideoDTO _video2 = new VideoDTO
        {
            CategoryId = 1,
            Id = 4,
            Name = "Video van een appel",
            VideoUrl = "VideoUrl2"
        };

        private readonly VideoDTO _video3 = new VideoDTO
        {
            CategoryId = 2,
            Id = 2,
            Name = "Video van een bus",
            VideoUrl = "VideoUrl2"
        };

        private readonly VideoDTO _video4 = new VideoDTO
        {
            CategoryId = 3,
            Name = "Video van een glas water",
            VideoUrl = "VideoUrl3"
        };

        public VideosControllerTest()
        {
            _videoServiceMock = new Mock<IVideoService>();
            _controller = new VideosController(_videoServiceMock.Object);

            _videos = new List<VideoDTO> {_video1, _video2, _video3};
        }

        [Fact]
        private void MethodGetVideosWithoutParamsReturnsAllVideos()
        {
            _videoServiceMock.Setup(repo => repo.GetAll()).Returns(_videos);

            var actionResult = _controller.GetVideos(null);
            Assert.IsType<OkObjectResult>(actionResult);

            var result = (OkObjectResult) actionResult;
            var responseObject = (ResponseObject) result.Value;
            Assert.Equal(_videos, responseObject.Data);
        }

        [Fact]
        private void MethodGetVideosWithCategoryIdReturnsAllVideosForThatCategory()
        {
            _videoServiceMock.Setup(repo => repo.GetAllByCategoryId(1)).Returns(_videos);

            var actionResult = _controller.GetVideos(1);
            Assert.IsType<OkObjectResult>(actionResult);

            var result = (OkObjectResult) actionResult;
            var responseObject = (ResponseObject) result.Value;
            Assert.Equal(_videos, responseObject.Data);
        }

        [Fact]
        private void MethodGetVideoWithVideoIdReturnsVideo()
        {
            _videoServiceMock.Setup(repo => repo.GetById(1)).Returns(_video1);

            var actionResult = _controller.GetVideo(1);
            Assert.IsType<OkObjectResult>(actionResult);

            var result = (OkObjectResult) actionResult;
            var responseObject = (ResponseObject) result.Value;
            Assert.Equal(_video1, responseObject.Data);
        }

        [Fact]
        private void ThrowsBadRequestWhenVideoIdNotExists()
        {
            _videoServiceMock.Setup(repo => repo.GetById(5555)).Throws(new NullReferenceException());

            var actionResult = _controller.GetVideo(5555);
            var result = (BadRequestObjectResult) actionResult;
            var statusCode = result.StatusCode;
            Assert.Equal(400, statusCode);
        }

        [Fact]
        private void MethodPostVideoAddsVideoInRepo()
        {
            _videoServiceMock.Setup(repo => repo.Add(_video4));
            
            var toPost = new ResponseObject {Data = _video4};

            var actionResult = _controller.PostVideo(toPost);
            Assert.IsType<OkObjectResult>(actionResult);

            var result = (OkObjectResult) actionResult;
            var responseObject = (ResponseObject) result.Value;
            Assert.Equal(_video4, responseObject.Data);

            _videoServiceMock.Verify(repo => repo.Add(_video4), Times.Once);
        }

        [Fact]
        private void MethodPostThrowsExceptionWhenModelInvalid()
        {
            _controller.ModelState.AddModelError("fakeError", "fakeError");

            var response = (BadRequestObjectResult) _controller.PostVideo(new ResponseObject());
            var statusCode = response.StatusCode;

            Assert.Equal(400, statusCode);
        }

        [Fact]
        private void MethodPostThrowsBadRequestWhenVideoIsNull()
        {
            var response = _controller.PostVideo(null);
            var result = (BadRequestResult) response;
            var statusCode = result.StatusCode;

            Assert.Equal(400, statusCode);
        }

        [Fact]
        private void MethodDeleteVideoDeletesVideoFromRepo()
        {
            _videoServiceMock.Setup(repo => repo.GetById(3)).Returns(_video3);
            _videoServiceMock.Setup(repo => repo.Delete(_video3));

            var actionResult = _controller.DeleteVideo(3);
            Assert.IsType<OkResult>(actionResult);

            _videoServiceMock.Verify(repo => repo.Delete(_video3), Times.Once);
        }

        [Fact]
        private void MethodDeleteVideoThrowsExceptionWhenInvalidId()
        {
            _videoServiceMock.Setup(repo => repo.GetById(1)).Throws(new NullReferenceException());
            _videoServiceMock.Setup(repo => repo.Delete(_video1)).Throws(new NullReferenceException());

            var actionResult = _controller.DeleteVideo(1);
            Assert.IsType<BadRequestObjectResult>(actionResult);

            var response = (BadRequestObjectResult) _controller.DeleteVideo(1);
            var statusCode = response.StatusCode;
            Assert.Equal(400, statusCode);
        }
    }
}