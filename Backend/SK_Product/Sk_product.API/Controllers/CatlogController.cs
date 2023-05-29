using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sk_product.BAL.IServices;
using Sk_product.BAL.Services;
using Sk_product.DAL.Models;

namespace Sk_product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CatlogController : ControllerBase
  {
    private readonly IcourseServices _courseservice;
    private IMemoryCache _memoryCache;
    public CatlogController(IcourseServices courseservice,IMemoryCache memoryCache)
    {
        _courseservice = courseservice;
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public IEnumerable<Course> GetAll()
    {
      string key = "catalog";
      var items = _memoryCache.GetOrCreate(key, entry =>
      {
        entry.AbsoluteExpiration = DateTime.Now.AddHours(12);
        entry.SlidingExpiration = TimeSpan.FromMinutes(15);
        var data = _courseservice.GetAllCourses();

        return data;
      });
      return items;
    }
    [HttpGet("{url}")]
    public Course GetCoursewithLesson(string url)
    {
      url = "/Courses/" + url;
      return _courseservice.GetCourseWithLesson(url);
    }

  }
}
