using Microsoft.AspNetCore.Mvc;
using MyFitnessApp.BLL;
using MyFitnessApp.Models;
using System;
using System.Collections.Generic;

namespace MyFitnessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiaryController : ControllerBase
    {
        public DiaryService _diaryService;

        public DiaryController(DiaryService diaryService)
        {
            _diaryService = diaryService;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<Diary> GetDiaries()
        {
            return _diaryService.GetAll();
        }

        [HttpGet]
        [Route("get/{id}")]
        public Diary GetDiary(int id)
        {
            var diary = _diaryService.Get(id);
            return diary;
        }

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
