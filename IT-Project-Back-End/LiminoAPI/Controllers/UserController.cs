using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LiminoAPI.Business;
using LiminoAPI.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace LiminoAPI.Controllers
{

    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] ResponseObject responseObject)
        {
            var json = JsonConvert.SerializeObject(responseObject.Data);
            var userDto = JsonConvert.DeserializeObject<UserDTO>(json);
            
            var user = _service.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest(new {message = "Username or password is incorrect"});

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("LiminoApiStringNeedsToBeLongEnoughToBeEncoded");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            
            var response = new ResponseObject
            {
                Data = new
                {
                    user.Id,
                    user.Username,
                    Token = tokenString
                }
            };
            return Ok(response);
        }


        [HttpPost("register")]
        public IActionResult Register([FromBody] ResponseObject responseObject)
        {
            var json = JsonConvert.SerializeObject(responseObject.Data);
            var userDTO = JsonConvert.DeserializeObject<UserDTO>(json);

            try
            {
                _service.Create(userDTO);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var responseObject = new ResponseObject {Data = _service.GetAll()};

            return Ok(responseObject);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            ResponseObject responseObject;
            try
            {
                responseObject = new ResponseObject {Data = _service.GetById(id)};
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            

            return Ok(responseObject);
        }
        

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] ResponseObject responseObject)
        {
            var json = JsonConvert.SerializeObject(responseObject.Data);
            var userDto = JsonConvert.DeserializeObject<UserDTO>(json);
            
            try
            {
                _service.Update(id, userDto);
                return Ok(id);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
    }
}