using System.Collections.Generic;

namespace LiminoAPI.Business.Services
{
    public interface IVideoService
    {
        IEnumerable<VideoDTO> GetAll();
        VideoDTO GetById(long id);
        long Add(VideoDTO video);
        void Delete(VideoDTO videoDto);
        IEnumerable<VideoDTO> GetAllByCategoryId(long? categoryId);
        VideoDTO Update(VideoDTO videoDTO);
    }
}
