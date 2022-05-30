﻿using Microsoft.AspNetCore.Mvc;
using MyFitnessApp.DAL;
using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using MyFitnessApp.BLL;

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
        [Route("update")]
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
                return Ok("User has been updated succesfully");
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