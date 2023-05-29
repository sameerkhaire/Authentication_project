using CommonEntity;
using DAL.Models;
using Services.ServiceInterface;

namespace Services.Interfaces
{
    public interface IOrderService: IService<Order>
    {
        OrderModel GetOrderDetails(string OrderId);
        IEnumerable<Order> GetUserOrders(int UserId);
        int PlaceOrder(PaymentModel model);
    }
}
