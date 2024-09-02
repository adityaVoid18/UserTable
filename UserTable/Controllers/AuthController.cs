using JwtExample.Services;

using Microsoft.AspNetCore.Mvc;
 
namespace JwtExample.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class AuthController : ControllerBase

    {

        private readonly JwtService _jwtService;
 
        public AuthController(JwtService jwtService)

        {

            _jwtService = jwtService;

        }
 
        [HttpPost("token")]

        public IActionResult GenerateToken([FromBody] string userName)

        {

            var token = _jwtService.GenerateToken(userName);

            return Ok(new { token });

        }

    }

}