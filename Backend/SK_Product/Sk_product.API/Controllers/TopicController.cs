using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk_product.BAL.IServices;
using Sk_product.DAL.Models;

namespace Sk_product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TopicController : ControllerBase
  {
    private readonly ITopicServices _services;
    public TopicController(ITopicServices topicServices)
    {
      _services = topicServices;
    }
    [HttpGet]
    public IEnumerable<CourseTopic> GetAllTopics()
    {
      return _services.GetAllTopics();
    }
    [HttpGet("{topicid}")]
    public IEnumerable<CourseTopic> GetTopics(int topicid)
    {
      return _services.GetTopicsByCourse(topicid);
    }
    [HttpGet("{id}")]
    public Task<CourseTopic> GetById(int id)
    {
      return _services.Find(id);
    }
    [HttpPost]
    public IActionResult AddTopic(CourseTopic courseTopic)
    {
      try
      {
        if(courseTopic != null)
        {
          _services.Add(courseTopic);
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
    public IActionResult Update(int id,CourseTopic courseTopic)
    {
      try
      {
        if (id== courseTopic.Id)
        {
          _services.Update(courseTopic);
        }
        return StatusCode(StatusCodes.Status304NotModified);

      }
      catch(Exception ex)
      {
        return StatusCode(StatusCodes.Status400BadRequest);
      }
    }
  }
}
