using Microsoft.AspNetCore.Mvc;
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
    public class UserGoalsController : ControllerBase
    {
        public UserGoalService _userGoalService;

        public UserGoalsController(UserGoalService userGoalService)
        {
            _userGoalService = userGoalService;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<UserGoal> GetUserGoals()
        {
            return _userGoalService.GetAll();
        }

        [HttpGet]
        [Route("get/{id}")]
        public UserGoal GetUserGoals(int id)
        {
            var userGoal = _userGoalService.Get(id);
            return userGoal;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(UserGoal userGoal)
        {
            try
            {
                if (userGoal is null)
                {
                    return BadRequest("User is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }
                _userGoalService.Create(userGoal);
                return Ok("User goal has been created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(UserGoal userGoal)
        {
            try
            {
                if (userGoal is null)
                {
                    return BadRequest("User goal is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }

                var userGoalToUpdate = _userGoalService.Get(userGoal.Id);

                if (userGoalToUpdate is null)
                {
                    return NotFound();
                }

                _userGoalService.Update(userGoal);
                return Ok("User goal has been updated succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(UserGoal userGoal)
        {
            try
            {
                var userGoalToDelete = _userGoalService.Get(userGoal.Id);
                if (userGoalToDelete == null)
                {
                    return NotFound();
                }
                _userGoalService.Delete(userGoal.Id);
                return Ok("User goal has been deleted succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
