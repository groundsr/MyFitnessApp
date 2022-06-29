using Microsoft.AspNetCore.Mvc;
using MyFitnessApp.BLL;
using MyFitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFitnessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiaryController : ControllerBase
    {
        public DiaryService _diaryService;
        private MealService _mealService;

        public DiaryController(DiaryService diaryService, MealService mealService)
        {
            _diaryService = diaryService;
            _mealService = mealService;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<Diary> GetDiaries()
        {
            return _diaryService.GetAll();
        }

        [HttpGet]
        [Route("get/{userid}")]
        public async Task<IActionResult> GetDiaryForUser(int userid)
        {
            var diary = await _diaryService.GetDiaryForUser(userid);
            return Ok(diary);
        }

        [HttpPost]
        [Route("addFoodToDiary")]
        public IActionResult AddFoodToDiary(int userId, string MealType, int mealId, int quantity)
        {
            var meal = _mealService.Get(mealId);
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
                _diaryService.AddFoodToDiary(userId, MealType, mealId, quantity);
                return Ok(meal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpDelete]
        [Route("deleteFoodFromDiary")]
        public IActionResult RemoveFoodFromDiary(int userid, string MealType, int mealId)
        {
            var meal = _mealService.Get(mealId);
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
                _diaryService.DeleteFoodFromDiary(userid, MealType, mealId);
                return Ok("Food has been deleted from today's diary");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        //[HttpGet]
        //[Route("get/{id}")]
        //public Diary GetDiary(int id)
        //{
        //    var diary = _diaryService.Get(id);
        //    return diary;
        //}

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Diary diary)
        {
            try
            {
                if (diary is null)
                {
                    return BadRequest("Diary is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }
                _diaryService.Create(diary);
                return Ok("Diary has been created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(Diary diary)
        {
            try
            {
                if (diary is null)
                {
                    return BadRequest("Diary is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object");
                }

                var diaryToUpdate = _diaryService.Get(diary.Id);

                if (diaryToUpdate is null)
                {
                    return NotFound();
                }

                _diaryService.Update(diary);
                return Ok("Diary has been updated succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Diary diary)
        {
            try
            {
                var diaryToDelete = _diaryService.Get(diary.Id);
                if (diaryToDelete == null)
                {
                    return NotFound();
                }
                _diaryService.Delete(diary.Id);
                return Ok("Diary has been deleted succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
