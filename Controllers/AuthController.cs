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
        private readonly UserProgressService _userProgressService;

        public AuthController(UserService userService, JwtService jwtService, UserProgressService userProgressService)
        {
            _userService = userService;
            _jwtService = jwtService;
            _userProgressService = userProgressService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterDto dto)
        {
            var userProgress = new UserProgress();
            userProgress.CurrentWeight = dto.Weight;
            userProgress.WeightLogDate = DateTime.Now;
            _userProgressService.Create(userProgress);
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                UserGoalId = dto.UserGoalId,
                Sex = dto.Sex,
                BirthDay = dto.Birthday,
                Height = dto.Height,
                Weight = dto.Weight,
                //Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
                Password = dto.Password,
            };
            //userProgress.User = user;
            //user.UserProgresses.Add(userProgress);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var diary = new Diary();
            diary.CreationDate = DateTime.Today;

            _userService.Create(user);
            userProgress.User = user;
            //diary.TotalCalories = user.UserGoal.UserPlan.TotalCalories;
            diary.User = user;
            _userProgressService.Save();

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
