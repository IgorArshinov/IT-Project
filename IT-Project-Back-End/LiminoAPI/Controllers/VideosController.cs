using System;
using System.ComponentModel;
using LiminoAPI.Business;
using LiminoAPI.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LiminoAPI.Controllers
{
    [Route("api/videos")]
    public class VideosController : Controller
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }
       
        [HttpGet]
        public IActionResult GetVideos(long? categoryId)
        {
            var response = new ResponseObject
            {
                Data = categoryId != null
                    ? _videoService.GetAllByCategoryId(categoryId)
                    : _videoService.GetAll()
            };
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetVideo(long id)
        {
            var response = new ResponseObject();
            try
            {
                response.Data = _videoService.GetById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }
        
        [HttpPost]
        public IActionResult PostVideo([FromBody] ResponseObject responseObject)
        {
            if (responseObject == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var json = JsonConvert.SerializeObject(responseObject.Data);
            var videoDTO = JsonConvert.DeserializeObject<VideoDTO>(json);
           
            videoDTO.Id = _videoService.Add(videoDTO);
            
            var response = new ResponseObject {Data = videoDTO};
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteVideo(long id)
        {
            VideoDTO videoDto;
            try
            {
                videoDto = _videoService.GetById(id);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            _videoService.Delete(videoDto);

            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateVideo([FromBody] ResponseObject responseObject)
        {
            var json = JsonConvert.SerializeObject(responseObject.Data);
            var videoDTO = JsonConvert.DeserializeObject<VideoDTO>(json);
            try
            {
                if (videoDTO == null || !ModelState.IsValid)
                {
                    return NotFound();
                }

                var response = new ResponseObject {Data = _videoService.Update(videoDTO)};

                return Ok(response);
            }
            catch (InvalidEnumArgumentException e)
            {
                return BadRequest(e);
            }
        }
    }
}