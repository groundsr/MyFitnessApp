using Microsoft.AspNetCore.Mvc;
using MyFitnessApp.BLL;
using MyFitnessApp.Models;
using System;
using System.Collections.Generic;

namespace MyFitnessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealController : ControllerBase
    {
        public MealService _mealService;

        public MealController(MealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<Meal> GetMeals()
        {
            return _mealService.GetAll();
        }

        [HttpGet]
        [Route("get/{id}")]
        public Meal GetMeal(int id)
        {
            var meal = _mealService.Get(id);
            return meal;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Meal meal)
        {
            try
            {
                if (meal is null)
                {
                    return BadRequest("Meal is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }
                _mealService.Create(meal);
                return Ok("Meal has been created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(Meal meal)
        {
            try
            {
                if (meal is null)
                {
                    return BadRequest("Meal is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }

                var mealToUpdate = _mealService.Get(meal.Id);

                if (mealToUpdate is null)
                {
                    return NotFound();
                }

                _mealService.Update(meal);
                return Ok("Meal has been updated succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Meal meal)
        {
            try
            {
                var mealToDelete = _mealService.Get(meal.Id);
                if (mealToDelete == null)
                {
                    return NotFound();
                }
                _mealService.Delete(meal.Id);
                return Ok("Meal has been deleted succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
