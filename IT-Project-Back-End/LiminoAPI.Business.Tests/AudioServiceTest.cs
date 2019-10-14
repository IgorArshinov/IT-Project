using System;
using System.Collections.Generic;
using LiminoAPI.Business.DTO_s;
using LiminoAPI.Business.Services;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;
using Moq;
using Xunit;

namespace LiminoAPI.Business.Tests
{
    public class AudioServiceTest
    {
        private readonly Mock<IBaseRepository<Audio>> _repoMock;
        private readonly AudioService _audioService;

        private readonly IList<AudioDTO> _audioDTOs;

        private readonly IList<Audio> _audios;


        private static readonly Category Category = new Category
            {Id = 1, ImageUrl = "imageUrl1", Name = "eten"};

        private readonly AudioDTO _audioDTO = new AudioDTO
            {Id = 1, ImageUrl = "imageUrl1", Name = "eten", CategoryId = 1, FragmentUrl = "fargmentUrl1"};

        private readonly AudioDTO _audio1DTO = new AudioDTO
            {Id = 2, ImageUrl = "imageUrl2", Name = "verkeer", CategoryId = 1, FragmentUrl = "fargmentUrl12"};

        private readonly AudioDTO _audio2DTO = new AudioDTO
            {Id = 3, ImageUrl = "imageUrl3", Name = "drinken", CategoryId = 1, FragmentUrl = "fargmentUrl3"};

        private readonly AudioDTO _audio3DTO = new AudioDTO
            {Id = 4, ImageUrl = "imageUrl4", Name = "wassen", CategoryId = 1, FragmentUrl = "fargmentUrl4"};

        private readonly Audio _audio = new Audio
        {
            Id = 1, ImageUrl = "imageUrl1", Name = "eten", CategoryId = 1, FragmentUrl = "fargmentUrl1",
            Category = Category
        };

        private readonly Audio _audio1 = new Audio
        {
            Id = 2, ImageUrl = "imageUrl2", Name = "verkeer", CategoryId = 1, FragmentUrl = "fargmentUrl2",
            Category = Category
        };

        private readonly Audio _audio2 = new Audio
        {
            Id = 3, ImageUrl = "imageUrl3", Name = "drinken", CategoryId = 1, FragmentUrl = "fargmentUrl3",
            Category = Category
        };

        private readonly Audio _audio3 = new Audio
        {
            Id = 4, ImageUrl = "imageUrl4", Name = "wassen", CategoryId = 1, FragmentUrl = "fargmentUrl4",
            Category = Category
        };


        public AudioServiceTest()
        {
            _repoMock = new Mock<IBaseRepository<Audio>>();
            _audioService = new AudioService(_repoMock.Object);

            _audioDTOs = new List<AudioDTO> {_audioDTO, _audio1DTO, _audio2DTO, _audio3DTO};
            _audios = new List<Audio> {_audio, _audio1, _audio2, _audio3};
        }

        [Fact]
        public void UpdateCallsRepositoryWithDTO()
        {
            _repoMock.Setup(repo => repo.Update(_audio)).Returns(_audio);

            var audioDTO = _audioService.Update(_audioDTO);

            Assert.Equal(_audioDTO, audioDTO);
            _repoMock.Verify(repo => repo.Update(_audio));
        }

        [Fact]
        public void AddCallsRepositoryWithDTO()
        {
            _repoMock.Setup(repo => repo.Add(_audio));

            _audioService.Add(_audioDTO);

            _repoMock.Verify(repo => repo.Add(_audio));
        }

        [Fact]
        public void DeleteCallsRepositoryWithDTO()
        {
            _repoMock.Setup(repo => repo.GetById(1)).Returns(_audio);
            _repoMock.Setup(repo => repo.Delete(_audio));

            _audioService.Delete(1);

            _repoMock.Setup(repo => repo.GetById(1)).Returns(_audio);
            _repoMock.Verify(repo => repo.Delete(_audio));
        }

        [Fact]
        public void GetAllReturnsAllAudio()
        {
            _repoMock.Setup(repo => repo.GetAll()).Returns(_audios);

            var audioDtos = _audioService.GetAll();

            _repoMock.Verify(repo => repo.GetAll());
            Assert.Equal(_audioDTOs, audioDtos);
        }

        [Fact]
        public void GetAllReturnsAllAudioByCategoryId()
        {
            _repoMock.Setup(repo => repo.GetAllWhere(It.IsAny<Func<Audio, bool>>())).Returns(_audios);

            var audioDtos = _audioService.GetAllAudiosByCategoryId(1);

            _repoMock.Verify(repo => repo.GetAllWhere(It.IsAny<Func<Audio, bool>>()));
            Assert.Equal(_audioDTOs, audioDtos);
        }

        [Fact]
        public void GetAudioByIdReturnsCorrectAudio()
        {
            _repoMock.Setup(repo => repo.GetById(1L)).Returns(_audio);

            var audio = _audioService.GetAudioById(1L);

            _repoMock.Verify(repo => repo.GetById(1L));
            Assert.Equal(_audioDTO, audio);
        }
    }
}