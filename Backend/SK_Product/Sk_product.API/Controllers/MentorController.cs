using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk_product.BAL.IServices;
using Sk_product.DAL.Models;

namespace Sk_product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MentorController : ControllerBase
  {
    private readonly ImentorServices _ImentorService;
    public MentorController(ImentorServices Imentorservices)
    {
      _ImentorService = Imentorservices;
    }
    [HttpGet]
    public IEnumerable<Mentor> GetAllMentor()
    {
      return _ImentorService.GetAllMentors();
    }
    [HttpGet("{id}")]
    public Task<Mentor> GetMentor(int id)
    {
      return _ImentorService.Find(id);
    }
  }
}
