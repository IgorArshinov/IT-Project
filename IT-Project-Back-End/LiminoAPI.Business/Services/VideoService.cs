using System;
using System.Collections.Generic;
using System.Linq;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;

namespace LiminoAPI.Business.Services
{
    public class VideoService : IVideoService
    {
        private readonly IBaseRepository<Video> _repository;

        public VideoService(IBaseRepository<Video> baseRepository)
        {
            _repository = baseRepository;
        }

        public IEnumerable<VideoDTO> GetAll()
        {
            var videos = _repository.GetAll();
            return MapEntityListToDtoList(videos);
        }

        public IEnumerable<VideoDTO> GetAllByCategoryId(long? categoryId)
        {
            return MapEntityListToDtoList(_repository.GetAllWhere(video => video.CategoryId == categoryId));
        }

        public VideoDTO GetById(long id)
        {
            var video = _repository.GetById(id);
            if (video == null)
            {
                throw new Exception();
            }

            return MapVideoToVideoDto(video);
        }

        public long Add(VideoDTO videoDto)
        {
            var video = MapVideoDtoToVideo(videoDto);
            return _repository.Add(video);
        }

        public void Delete(VideoDTO videoDto)
        {
            _repository.Delete(MapVideoDtoToVideo(videoDto));
        }

        private static IEnumerable<VideoDTO> MapEntityListToDtoList(IEnumerable<Video> videos)
        {
            return videos.Select(video => new VideoDTO()
            {
                Id = video.Id,
                Name = video.Name,
                VideoUrl = video.VideoUrl,
                CategoryId = video.CategoryId
            }).ToList();
        }

        private static VideoDTO MapVideoToVideoDto(Video video)
        {
            return new VideoDTO
            {
                Id = video.Id,
                VideoUrl = video.VideoUrl,
                CategoryId = video.CategoryId,
                Name = video.Name
            };
        }

        private static Video MapVideoDtoToVideo(VideoDTO video)
        {
            return new Video
            {
                Id = video.Id,
                VideoUrl = video.VideoUrl,
                CategoryId = video.CategoryId,
                Name = video.Name
            };
        }
        
        public VideoDTO Update(VideoDTO videoDTO)
        {
            return MapVideoToVideoDto(_repository.Update(MapVideoDtoToVideo(videoDTO)));
        }
    }
}