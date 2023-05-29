using CommonEntity;
using DAL.Models;
using Repositories.Interface;

namespace Repositories.IRepository
{
    public interface IOrderRepository : IBaseRepo<Order>
    {
        OrderModel GetOrderDetails(string id);
        IEnumerable<Order> GetUserOrders(int UserId);
        PagingListModel<OrderModel> GetOrderList(int page, int pageSize);
    }
}
