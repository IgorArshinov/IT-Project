using System.Collections.Generic;
using LiminoAPI.Business.DTO_s;
using LiminoAPI.Data.Models;

namespace LiminoAPI.Business.Services
{
    public interface IAudioService
    {
        AudioDTO Update(AudioDTO entityDTO);
        long Add(AudioDTO addDto);
        void Delete(long id);
        IEnumerable<AudioDTO> GetAll();
        IEnumerable<AudioDTO> GetAllAudiosByCategoryId(long id);
        AudioDTO GetAudioById(long id);
    }
}