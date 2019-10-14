using System.ComponentModel;
using LiminoAPI.Business.DTO_s;
using LiminoAPI.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LiminoAPI.Controllers
{
    [Route("api/audios")]
    public class AudioController : ControllerBase
    {
        private readonly IAudioService _audioService;

        public AudioController(IAudioService audioService)
        {
            _audioService = audioService;
        }
        
        [HttpGet]
        public IActionResult GetAll(long? categoryId)
        {
            try
            {
                var response = new ResponseObject
                {
                    Data = categoryId != null
                        ? _audioService.GetAllAudiosByCategoryId(categoryId.Value)
                        : _audioService.GetAll()
                };

                return Ok(response);
            }
            catch (InvalidEnumArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAudioById(long id)
        {
            try
            {
                var response = new ResponseObject
                {
                    Data = _audioService.GetAudioById(id)
                };

                return Ok(response);
            }
            catch (InvalidEnumArgumentException e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public IActionResult AddNewAudio([FromBody] ResponseObject responseObject)
        {
            try
            {
                if (responseObject == null || !ModelState.IsValid)
                {
                    return NotFound();
                }
                var json = JsonConvert.SerializeObject(responseObject.Data);
                var audioDTO = JsonConvert.DeserializeObject<AudioDTO>(json);
                
                audioDTO.Id = _audioService.Add(audioDTO);
                var response = new ResponseObject {Data = audioDTO};

                return Ok(response);
            }
            catch (InvalidEnumArgumentException e)
            {
                return BadRequest(e);
            }
        }
        
        [HttpPut ("{id}")]
        public IActionResult UpdateAudio([FromBody] ResponseObject responseObject)
        {
            var json = JsonConvert.SerializeObject(responseObject.Data);
            var audioDto = JsonConvert.DeserializeObject<AudioDTO>(json);
            try
            {
                if (audioDto == null || !ModelState.IsValid)
                {
                    return NotFound();
                }

                var response = new ResponseObject {Data = _audioService.Update(audioDto)};

                return Ok(response);
            }
            catch (InvalidEnumArgumentException e)
            {
                return BadRequest(e);
            }
        }
        
        [HttpDelete]
        public IActionResult DeleteAudio(long id)
        {
            try
            {
                var audio = _audioService.GetAudioById(id);

                if (audio == null)
                {
                    return NotFound();
                }

                _audioService.Delete(id);

                return Ok();
            }
            catch (InvalidEnumArgumentException e)
            {
                return BadRequest(e);
            }
        }
    }
}