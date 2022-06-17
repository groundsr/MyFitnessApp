using Microsoft.AspNetCore.Mvc;
using MyFitnessApp.BLL;
using MyFitnessApp.Models;
using System;
using System.Collections.Generic;

namespace MyFitnessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        public ExerciseService _exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<Exercise> GetExercises()
        {
            return _exerciseService.GetAll();
        }

        [HttpGet]
        [Route("get/{id}")]
        public Exercise GetExercise(int id)
        {
            var exercise = _exerciseService.Get(id);
            return exercise;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Exercise exercise)
        {
            try
            {
                if (exercise is null)
                {
                    return BadRequest("Exercise is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }
                _exerciseService.Create(exercise);
                return Ok("Exercise has been created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(Exercise exercise)
        {
            try
            {
                if (exercise is null)
                {
                    return BadRequest("Exercise is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }

                var exerciseToUpdate = _exerciseService.Get(exercise.Id);

                if (exerciseToUpdate is null)
                {
                    return NotFound();
                }

                _exerciseService.Update(exercise);
                return Ok("Exercise has been updated succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Exercise exercise)
        {
            try
            {
                var exerciseToDelete = _exerciseService.Get(exercise.Id);
                if (exerciseToDelete == null)
                {
                    return NotFound();
                }
                _exerciseService.Delete(exercise.Id);
                return Ok("Exercise has been deleted succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
