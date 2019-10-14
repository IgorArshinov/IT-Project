using System;
using System.ComponentModel;
using LiminoAPI.Business;
using LiminoAPI.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LiminoAPI.Controllers
{
    [Route("api/exercises")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _service;

        public ExerciseController(IExerciseService service)
        {
            _service = service;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetExerciseById(long id)
        {
            var response = new ResponseObject();
            try
            {
                response.Data = _service.GetById(id);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            return Ok(response);
        }
        
        [HttpGet]
        public IActionResult GetExercises(long? categoryId, string type = "all")
        {
            try
            {
                var response = new ResponseObject
                {
                    Data = type.ToLower().Equals("all")
                        ? _service.GetAllForCategoryId(categoryId)
                        : _service.GetAllExercisesByTypeAndCategory(type, categoryId)
                };
                return Ok(response);
            }  catch (InvalidEnumArgumentException exception){
                return BadRequest(exception.Message);
            }
        }
        
        [HttpPost]
        public IActionResult PostExercise([FromBody] ResponseObject responseObject)
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
            var exerciseDTO = JsonConvert.DeserializeObject<ExerciseDTO>(json);
            
            exerciseDTO.Id = _service.Add(exerciseDTO);

            return Ok(new ResponseObject { Data = exerciseDTO });
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteExercise(long id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateExercise([FromBody] ResponseObject responseObject)
        {
            var json = JsonConvert.SerializeObject(responseObject.Data);
            var exerciseDTO = JsonConvert.DeserializeObject<ExerciseDTO>(json);
            
            try
            {
                _service.Put(exerciseDTO);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            return Ok(new ResponseObject { Data = exerciseDTO });
        }
    }
}