using Microsoft.Extensions.Configuration;
using Sk_product.BAL.IServices;
using Sk_product.Common.CommonModel;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using Sk_product.DAL.Repository;
namespace Sk_product.BAL.Services
{
  public class OrderService : Service<Order>, IorderServices
  {
    private readonly OrderRepo _orderrepo;
    private readonly IBaseRepository<Subscription> _subscriptions;
    private readonly IConfiguration _config;
    public OrderService(OrderRepo orderRepo, IBaseRepository<Subscription> subscriptions, IConfiguration config, IBaseRepository<Order> repository) : base(repository)
    {
      _orderrepo = orderRepo;
      _subscriptions = subscriptions;
       _config = config;
    }

    public OrderModel GetOrderDetails(string OrderId)
    {
      var model=_orderrepo.GetOrderDetails(OrderId);
      if(model != null && model.Items.Count>0)
      {
        decimal subtotal = 0;
        foreach(var item in model.Items)
        {
          item.Total=item.UnitPrice*item.Quantity;
          subtotal += item.Total;
        }
        model.Total = subtotal;
        //tax calculations
        decimal taxrate = Convert.ToInt32(_config["Tax:TaxRate"]);
        model.Tax = Math.Round((model.Total * taxrate) / 100, 2);
        model.GrandTotal = model.Tax + model.Total;
      }
      return model;
    }

    public IEnumerable<Order> GetUserOrders(int UserId)
    {
      return _orderrepo.GetUserOrders(UserId);
    }

    public int PlaceOrder(PaymentModel model)
    {
      Order orders = new Order
      {
        Id= model.OrderId,
        UserId=model.UserId,
        CreatedDate= DateTime.Now,

      };
      List<Subscription> subscriptions = new List<Subscription>();
      foreach(var item in model.Items)
      {
        OrderItem orderItem = new OrderItem
        {
          ItemId=item.ItemId,
          UnitPrice=item.UnitPrice,
          Quantity=item.Quantity,
          Total=item.Total
        };
        orders.OrderItems.Add(orderItem);
        //Assign Subscriptions
        Subscription subscription = new Subscription
        {
          UserId=model.UserId,
          CourseId=item.ItemId,
          SubscribedOn=DateTime.Now
        };
        subscriptions.Add(subscription);
      }
      _subscriptions.AddRange(subscriptions);
      _orderrepo.Add(orders);
      return _orderrepo.savChage();
    }
  }
}
