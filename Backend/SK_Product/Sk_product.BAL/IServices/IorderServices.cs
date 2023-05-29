using Sk_product.Common.CommonModel;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.IServices
{
  public interface IorderServices : Iservice<Order>
  {
    OrderModel GetOrderDetails(string OrderId);
    IEnumerable<Order> GetUserOrders(int UserId);
    int PlaceOrder(PaymentModel model);
  }
}
