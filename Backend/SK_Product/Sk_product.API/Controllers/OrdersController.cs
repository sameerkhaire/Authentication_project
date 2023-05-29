using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk_product.BAL.IServices;
using Sk_product.Common.CommonModel;
using Sk_product.DAL.Models;

namespace Sk_product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrdersController : ControllerBase
  {
    private readonly IorderServices _orderservices;
    public OrdersController(IorderServices orderServices)
    {
      _orderservices = orderServices;   
    }
    [HttpGet("{userId}")]
    public IEnumerable<Order> GetUserOrder(int userId)
    {
      return _orderservices.GetUserOrders(userId);
    }
    [HttpGet("{orderId}")]
    public OrderModel GetOrderDetails(string orderId)
    {
      return _orderservices.GetOrderDetails(orderId);
    }

  }
}
