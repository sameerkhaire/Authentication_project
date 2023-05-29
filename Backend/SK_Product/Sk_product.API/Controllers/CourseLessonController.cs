using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk_product.BAL.IServices;
using Sk_product.BAL.Services;
using Sk_product.DAL.Models;
using System.Reflection.Metadata.Ecma335;

namespace Sk_product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CourseLessonController : ControllerBase
  {
    private readonly ILessonServices _lessonServices;
    public CourseLessonController(ILessonServices lessonServices)
    {
        _lessonServices = lessonServices;
    }
    [HttpGet]
    public Task<List<CourseLesson>> GetAll()
    {
     return  _lessonServices.GetAll();
    }
    [HttpGet("{topic_id}")]
    public IEnumerable<CourseLesson> GetCourseByTopic(int topic_id)
    {
      return _lessonServices.GetLessons(topic_id);
    }
    [HttpGet("{id}")]
    public Task<CourseLesson> GetById(int id)
    {
      return _lessonServices.Find(id);
    }
    [HttpPost]
    public IActionResult Add(CourseLesson courseLesson)
    {
      try
      {
        if (courseLesson != null)
        {
          _lessonServices.Add(courseLesson);
          return StatusCode(StatusCodes.Status200OK);
        }
        return StatusCode(StatusCodes.Status400BadRequest);
      }
      catch(Exception)
      {
        return StatusCode(StatusCodes.Status400BadRequest);
      }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      try
      {
        if (id != 0)
        {
          _lessonServices.Delete(id);
          return StatusCode(StatusCodes.Status200OK);
        }
        return StatusCode(StatusCodes.Status400BadRequest);
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status400BadRequest);
      }
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id,CourseLesson model)
    {
      try
      {
        if (id != model.Id)
        {
          return StatusCode(StatusCodes.Status400BadRequest);
        }
        _lessonServices.Update(model);
        return StatusCode(StatusCodes.Status200OK);
      }
      catch (Exception )
      {
        return StatusCode(StatusCodes.Status400BadRequest);
      }
    }
  }
}
