using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LiminoAPI.Controllers
{
    [Route("api/upload")]
    public class UploadController : Controller
    {
        private readonly IConfiguration _configuration;

        public UploadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpPost]  
        public async Task<IActionResult> UploadFile(IFormFile file)  
        {  
            if (file == null || file.Length == 0)  
                return Content("file not selected");
            
            //var location = _configuration.GetSection("Location").GetSection("Directory").Value;
            var location = "/var/www/limino/html/assets/";
            var fileGuid = Guid.NewGuid().ToString();

            var pathToReturn = Path.GetFileName(fileGuid + Path.GetExtension(file.FileName));
            var pathToSave =  location + pathToReturn;
            Directory.CreateDirectory(location);
            
            using (var stream = new FileStream(pathToSave, FileMode.Create))  
            {  
                await file.CopyToAsync(stream);  
            }

            var response = new ResponseObject {Data = pathToReturn};
            return Ok(response);
        }  
    }
}