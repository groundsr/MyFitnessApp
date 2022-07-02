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
    public class UserPlansController : ControllerBase
    {
        public UserPlanService _userPlanService;

        public UserPlansController(UserPlanService userPlanService)
        {
            _userPlanService = userPlanService;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<UserPlan> GetUserPlans()
        {
            return _userPlanService.GetAll();
        }

        [HttpGet]
        [Route("get/{id}")]
        public UserPlan GetUserPlan(int id)
        {
            var userPlan = _userPlanService.Get(id);
            return userPlan;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(UserPlan userPlan)
        {
            try
            {
                if (userPlan is null)
                {
                    return BadRequest("User is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }
                _userPlanService.Create(userPlan);
                return Ok(userPlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(UserPlan userPlan)
        {
            try
            {
                if (userPlan is null)
                {
                    return BadRequest("User plan is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }

                var userPlanToUpdate = _userPlanService.Get(userPlan.Id);

                if (userPlanToUpdate is null)
                {
                    return NotFound();
                }

                _userPlanService.Update(userPlan);
                return Ok("User plan has been updated succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var userToDelete = _userPlanService.Get(id);
                if (userToDelete == null)
                {
                    return NotFound();
                }
                _userPlanService.Delete(id);
                return Ok("User plan has been deleted succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
