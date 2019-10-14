using System.Collections.Generic;
using System.Linq;
using LiminoAPI.Business.DTO_s;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;

namespace LiminoAPI.Business.Services
{
    public class AudioService : IAudioService
    {
        private readonly IBaseRepository<Audio> _audioRepository;

        public AudioService(IBaseRepository<Audio> repository)
        {
            _audioRepository = repository;
        }


        public AudioDTO Update(AudioDTO entityDTO)
        {
            return MapAudioEntToAudioDto(_audioRepository.Update(MapAudioDtoToAudioEnt(entityDTO)));
        }

        public long Add(AudioDTO addDto)
        {
            return _audioRepository.Add(MapAudioDtoToAudioEnt(addDto));
        }

        public void Delete(long id)
        {
            _audioRepository.Delete(_audioRepository.GetById(id));
        }

        public IEnumerable<AudioDTO> GetAll()
        {
            return MapIEAudioEntToAudioDto(_audioRepository.GetAll());
        }

        public IEnumerable<AudioDTO> GetAllAudiosByCategoryId(long id)
        {
            return MapIEAudioEntToAudioDto(_audioRepository.GetAllWhere(x => x.CategoryId == id));
        }

        public AudioDTO GetAudioById(long id)
        {
            return MapAudioEntToAudioDto(_audioRepository.GetById(id));
        }

        private static IEnumerable<AudioDTO> MapIEAudioEntToAudioDto(IEnumerable<Audio> ent)
        {
            return ent.Select(audio =>
                new AudioDTO
                {
                    Id = audio.Id,
                    CategoryId = audio.CategoryId,
                    FragmentUrl = audio.FragmentUrl,
                    ImageUrl = audio.ImageUrl,
                    Name = audio.Name
                }
            );
        }

        private static AudioDTO MapAudioEntToAudioDto(Audio ent)
        {
            return new AudioDTO
            {
                Id = ent.Id,
                CategoryId = ent.CategoryId,
                FragmentUrl = ent.FragmentUrl,
                ImageUrl = ent.ImageUrl,
                Name = ent.Name
            };
        }

        private static Audio MapAudioDtoToAudioEnt(AudioDTO ent)
        {
            return new Audio
            {
                Id = ent.Id,
                CategoryId = ent.CategoryId,
                FragmentUrl = ent.FragmentUrl,
                ImageUrl = ent.ImageUrl,
                Name = ent.Name
            };
        }
    }
}