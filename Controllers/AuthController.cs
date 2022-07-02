using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using MyFitnessApp.BLL;
using MyFitnessApp.Dtos;
using MyFitnessApp.Helpers;
using MyFitnessApp.Models;
using System;

namespace MyFitnessApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserService _userService;
        private readonly JwtService _jwtService;

        public AuthController(UserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                //UserGoal = dto.UserGoal,
                UserGoalId = dto.UserGoalId,
                Sex = dto.Sex,
                BirthDay = dto.Birthday,
                Height = dto.Height,
                Weight = dto.Weight,
                //Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
                Password = dto.Password,
            };

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            _userService.Create(user);
            return Created("success", user);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _userService.GetByEmail(dto.Email);

            if (user == null) return BadRequest("Invalid Credentials");

            //if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            if(dto.Password != user.Password)
            {
                return BadRequest("Invalid Credentials");
            }

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
            });

            return Ok(user);
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _userService.Get(userId);
                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
            });
            return Ok(new
            {
                message = "success"
            });
        }
    }
}
