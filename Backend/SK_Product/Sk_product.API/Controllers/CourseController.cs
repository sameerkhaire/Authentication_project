using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk_product.BAL.IServices;
using Sk_product.DAL.Models;

namespace Sk_product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CourseController : ControllerBase
  {
    private readonly IcourseServices _services;
    private readonly IsubscriptionServices _subscriptionServices;
    public CourseController(IcourseServices services, IsubscriptionServices subscriptionServices)
    {
      _services = services;
      _subscriptionServices = subscriptionServices;
    }

    [HttpGet]
    public Task<List<Course>> GetAll()
    {
      return _services.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Course> Get(int id)
    {
      return _services.Find(id);
    }
    [HttpPost]
    public IActionResult Post(Course course)
    {
      try
      {
        _services.Add(course);
        return StatusCode(StatusCodes.Status201Created);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status400BadRequest);
      }
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id,Course course)
    {
      try
      {
        if (id == course.Id)
        {
          _services.Update(course);
          return StatusCode(StatusCodes.Status200OK);
        }
        return StatusCode(StatusCodes.Status400BadRequest);
      }catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status400BadRequest);
      }
    }
    [HttpGet("{UserId}/{CourseId}")]
    public Subscription GetUserSubscriptions(int UserId, int CourseId)
    {
      return _subscriptionServices.GetUserSubscription(UserId, CourseId);
    }
    [HttpGet("{UserId}")]
    public IEnumerable<Course> GetSubscriptions(int UserId)
    {
      return _subscriptionServices.GetSubscribedCourses(UserId);
    }
  }
}
