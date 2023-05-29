using Sk_product.Common.CommonModel;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.DAL.IRepository
{
  public interface IorderRepo:IBaseRepository<Order>
  {
    OrderModel GetOrderDetails(string orderid);
    IEnumerable<Order> GetUserOrders(int UserId);
    PagingListModel<OrderModel> GetOrderList(int page, int pageSize);
  }
}
