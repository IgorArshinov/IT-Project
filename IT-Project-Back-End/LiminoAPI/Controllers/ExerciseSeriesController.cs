using System;
using LiminoAPI.Business;
using LiminoAPI.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LiminoAPI.Controllers
{
    [Route("api/exerciseSeries")]
    public class ExerciseSeriesController : ControllerBase
    {
        private readonly IExerciseSeriesService _service;

        public ExerciseSeriesController(IExerciseSeriesService exerciseSeriesService)
        {
            _service = exerciseSeriesService;
        }

        [HttpGet ("{id}")]
        public IActionResult GetExerciseSeriesByCode(long id)
        {
            var response = new ResponseObject();
            try
            {
                response.Data = _service.GetByCode(id);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok(response);
        }

//    [HttpGet("{id}")]
//        public IActionResult GetExerciseSeriesById(long id)
//        {
//            var response = new ResponseObject();
//            try
//            {
//                response.Data = _service.GetById(id);
//            }
//            catch (Exception exception)
//            {
//                return BadRequest(exception.Message);
//            }
//            return Ok(response);
//        }

//        [HttpGet]
        public IActionResult GetExerciseSeries()
        {
            var response = new ResponseObject();
            try
            {
                response.Data = _service.GetAllSeries();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostExerciseSeries([FromBody] ResponseObject responseObject)
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
            var exerciseSeriesDTO = JsonConvert.DeserializeObject<ExerciseSeriesDTO>(json);


            var response = new ResponseObject {Data = _service.Add(exerciseSeriesDTO)};
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteExerciseSeries(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
        public IActionResult UpdateExerciseSeries([FromBody] ResponseObject responseObject)
        {
            var json = JsonConvert.SerializeObject(responseObject.Data);
            var exerciseSeriesDTO = JsonConvert.DeserializeObject<ExerciseSeriesDTO>(json);

            try
            {
                _service.Update(exerciseSeriesDTO);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            var response = new ResponseObject {Data = exerciseSeriesDTO};
            return Ok(response);
        }  
    }
}