using Microsoft.AspNetCore.Mvc;
using MyFitnessApp.BLL;
using MyFitnessApp.Models;
using System;
using System.Collections.Generic;

namespace MyFitnessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<User> GetUsers()
        {
            return _userService.GetAll();
        }

        [HttpGet]
        [Route("get/{id}")]
        public User GetUser(int id)
        {
            var user = _userService.Get(id);
            return user;
        }
        [HttpPost]
        [Route("setWeight/{id}")]
        public IActionResult SetCurrentWeight(int weight, int id)
        {
            var user = GetUser(id);
            try
            {
                if (user is null)
                {
                    return BadRequest("User is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }

                var userToUpdate = _userService.Get(user.Id);

                if (userToUpdate is null)
                {
                    return NotFound();
                }

                _userService.SetCurrentWeight(weight, id);
                //return Ok("User has been updated succesfully");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(User user)
        {
            try
            {
                if (user is null)
                {
                    return BadRequest("User is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }
                _userService.Create(user);
                return Ok("User has been created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(User user)
        {
            try
            {
                if (user is null)
                {
                    return BadRequest("User is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }

                var userToUpdate = _userService.Get(user.Id);

                if (userToUpdate is null)
                {
                    return NotFound();
                }

                _userService.Update(user);
                //return Ok("User has been updated succesfully");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(User user)
        {
            try
            {
                var userToDelete = _userService.Get(user.Id);
                if (userToDelete == null)
                {
                    return NotFound();
                }
                _userService.Delete(user.Id);
                return Ok("User has been deleted succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
