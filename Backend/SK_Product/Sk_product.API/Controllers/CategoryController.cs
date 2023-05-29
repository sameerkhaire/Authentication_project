using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk_product.BAL.IServices;
using Sk_product.DAL.Models;

namespace Sk_product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    Iservice<Category> _service;
    public CategoryController(Iservice<Category> service)
    {
      _service = service;
    }
    [HttpGet]
    public Task<List<Category>> GetAllCategory()
    {
      return _service.GetAll();
    }
  }
}
