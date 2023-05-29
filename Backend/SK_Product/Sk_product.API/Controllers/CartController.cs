using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk_product.BAL.IServices;
using Sk_product.BAL.Services;
using Sk_product.DAL.Models;

namespace Sk_product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CartController : ControllerBase
  {
    private readonly IcartServices _cartservice;
    public CartController(IcartServices cartService)
    {
        _cartservice = cartService;
    }
    [HttpPost]
    public ActionResult<bool> SaveCart(Cart cart)
    {
       return _cartservice.SaveCart(cart);
    }

  }
}
