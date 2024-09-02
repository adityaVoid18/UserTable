//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.Security.Claims;
//using System.Text;
//using UserTable.DTO;
//using UserTable.Service;
//using System;
//using System.IdentityModel.Tokens.Jwt;
//using UserTable.Models;

//namespace UserTable.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IUserService _userService;

//        public AuthController(IUserService userService)
//        {
//            _userService = userService;
//        }
//        [HttpPost("authenticate")]
//        public async Task<IActionResult> Authenticate([FromBody] UserDataTable userDataTable)
//        {
//           // var response = await _userService.AuthenticateAsync(userDataTable.Username, userDataTable.Password);
//           var response =await _userService.AuthenticateAsync(userDataTable.Username,userDataTable.Password);

//            if (response == null)
//                return BadRequest(new { message = "Username or password is incorrect" });

//            return Ok(response);
//        }



//        // Register endpoint
//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] UserDataTable userDataTable)
//        {
//            if (userDataTable == null || string.IsNullOrWhiteSpace(userDataTable.Username) || string.IsNullOrWhiteSpace(userDataTable.Password))
//            {
//                return BadRequest(new { message = "Username and password are required" });
//            }

//            var result = await _userService.RegisterAsync(userDataTable);

//            if (result)
//                return Ok(new { message = "User registered successfully" });
//            else
//                return BadRequest(new { message = "User registration failed" });
//        }
//    }

    
    
//}

