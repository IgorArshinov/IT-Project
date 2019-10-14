using System.Collections.Generic;
using System.ComponentModel;
using LiminoAPI.Business;
using LiminoAPI.Business.DTO_s;
using LiminoAPI.Business.Services;
using LiminoAPI.Controllers;
using LiminoAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LiminoAPI.Tests
{
    public class AudioControllerTest
    {
        private readonly Mock<IAudioService> _audioServiceMock;

        private readonly AudioController _controller;
        private readonly IEnumerable<AudioDTO> _audios;

        private readonly AudioDTO _audio1 = new AudioDTO
        {
            CategoryId = 1,
            Id = 1,
            Name = "Audio van een banaan",
            ImageUrl = "AudioUrl1",
            FragmentUrl = "FragmentUrl1"
        };

        private readonly AudioDTO _audio2 = new AudioDTO
        {
            CategoryId = 1,
            Id = 4,
            Name = "Audio van een appel",
            ImageUrl = "AudioUrl2",
            FragmentUrl = "FragmentUrl2"
        };


        public AudioControllerTest()
        {
            _audioServiceMock = new Mock<IAudioService>();
            _controller = new AudioController(_audioServiceMock.Object);

            _audios = new List<AudioDTO> {_audio1, _audio2};
        }

        [Fact]
        public void GetAllAudiosByWithoutCategoryIdReturnsAllCategories()
        {
            _audioServiceMock.Setup(service => service.GetAll()).Returns(_audios);

            var result = (OkObjectResult) _controller.GetAll(null);
            var responseObject = (ResponseObject) result.Value;

            Assert.Equal(_audios, responseObject.Data);
        }

        [Fact]
        public void GetAllAudiosByWithCategoryIdReturnsAllCategoriesForThatCategory()
        {
            _audioServiceMock.Setup(service => service.GetAllAudiosByCategoryId(1)).Returns(_audios);

            var result = (OkObjectResult) _controller.GetAll(1);
            var responseObject = (ResponseObject) result.Value;

            Assert.Equal(_audios, responseObject.Data);
        }

        [Fact]
        public void GetAllAudiosByReturnsBadRequestOnThrows()
        {
            _audioServiceMock.Setup(service => service.GetAll()).Throws<InvalidEnumArgumentException>();

            var result = _controller.GetAll(null);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetAudioByIdReturnsAudio()
        {
            _audioServiceMock.Setup(service => service.GetAudioById(1)).Returns(_audio1);

            var result = (OkObjectResult) _controller.GetAudioById(1);
            var responseObject = (ResponseObject) result.Value;

            Assert.Equal(_audio1, responseObject.Data);
        }

        [Fact]
        public void GetAudioByIdReturnsBadRequestOnThrows()
        {
            _audioServiceMock.Setup(service => service.GetAudioById(1)).Throws<InvalidEnumArgumentException>();

            var result = _controller.GetAudioById(1);

            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public void AddNewAudioReturnsNewAudioWithId()
        {
            var audio = new AudioDTO
            {
                CategoryId = 1,
                Name = "Audio van een banaan",
                ImageUrl = "AudioUrl1",
                FragmentUrl = "FragmentUrl1"
            };
            _audioServiceMock.Setup(service => service.Add(audio)).Returns(1);
            var toPost = new ResponseObject {Data = audio};
            var result = (OkObjectResult) _controller.AddNewAudio(toPost);
            var responseObject = (ResponseObject) result.Value;

            Assert.Equal(_audio1, responseObject.Data);
        }

        [Fact]
        public void AddNewAudioReturnsBadRequestOnThrows()
        {
            _audioServiceMock.Setup(service => service.Add(_audio1)).Throws<InvalidEnumArgumentException>();

            var toPost = new ResponseObject {Data = _audio1};
            var result = _controller.AddNewAudio(toPost);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void AddNewAudioReturnsBadRequestOnNull()
        {
            var result = _controller.AddNewAudio(null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteAudioReturnsOk()
        {
            _audioServiceMock.Setup(service => service.GetAudioById(1)).Returns(_audio1);
            _audioServiceMock.Setup(service => service.Delete(1));

            var result = _controller.DeleteAudio(1);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteAudioNotFoundReturnsBadRequest()
        {
            var result = _controller.DeleteAudio(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteAudioReturnsBadRequestOnThrows()
        {
            _audioServiceMock.Setup(service => service.GetAudioById(1)).Returns(_audio1);
            _audioServiceMock.Setup(service => service.Delete(1)).Throws<InvalidEnumArgumentException>();

            var result = _controller.DeleteAudio(1);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateAudioNotFoundReturnsBadRequest()
        {
            var result = _controller.UpdateAudio(null);

            Assert.IsType<NotFoundResult>(result);
        }

        /*
        [Fact]
        public void UpdateAudioReturnsBadRequestOnThrows()
        {
            _audioServiceMock.Setup(service => service.Update(_audio1)).Throws<InvalidEnumArgumentException>();

            var result = _controller.UpdateAudio(_audio1);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateAudioReturnsUpdatedAudio()
        {
            var audio = new AudioDTO
            {
                CategoryId = 1,
                Name = "Audio van een banaan",
                ImageUrl = "AudioUrl1",
                FragmentUrl = "FragmentUrl1"
            };
            _audioServiceMock.Setup(service => service.Update(audio)).Returns(_audio1);


            var result = (OkObjectResult) _controller.UpdateAudio(audio);
            var responseObject = (ResponseObject) result.Value;

            Assert.Equal(_audio1, responseObject.Data);
        }
        */
    }
}