using System.ComponentModel;
using LiminoAPI.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiminoAPI.Controllers
{
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCategories()
        {
            try
            {
                var response = new ResponseObject
                {
                    Data = _categoryService.GetAllCategories()     
                };
                return Ok(response);
            }
            catch (InvalidEnumArgumentException e)
            {
                return BadRequest(e);
            }
        }
    }
}