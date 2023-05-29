using PagedList;
using Sk_product.Common.CommonModel;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.DAL.Repository
{
  public class OrderRepo : BaseRepository<Order>, IorderRepo
  {
    private readonly Sk_productContext _context;
    public OrderRepo(Sk_productContext context) : base(context)
    {
      _context = context;
    }

    public OrderModel GetOrderDetails(string orderid)
    {
      var data = (from order in _context.Orders
                  where order.Id == orderid
                  select new OrderModel
                  {
                    Id = order.Id,
                    UserId = order.UserId,
                    CreatedDate = order.CreatedDate,
                    Items = (from orderitem in _context.OrderItems
                             join ordercourse in _context.Courses on orderitem.ItemId equals ordercourse.Id
                             where orderitem.OrderId == orderid
                             select new ItemModel
                             {
                               Id = orderitem.Id,
                               Name = ordercourse.Name,
                               Description = ordercourse.Summary,
                               ItemId = ordercourse.Id,
                               UnitPrice = orderitem.UnitPrice,
                               Quantity = orderitem.Quantity,
                               ImageUrl = ordercourse.ImageUrl
                             }).ToList()
                  }).FirstOrDefault();
      return data;
    }

    public PagingListModel<OrderModel> GetOrderList(int page, int pageSize)
    {
      var pagingmodel= new PagingListModel<OrderModel>();
      var data = (from order in _context.Orders
                  join orderpayment in _context.PaymentDetails on order.PaymentId equals orderpayment.Id
                  select new OrderModel
                  {
                    Id = order.Id,
                    UserId = orderpayment.UserId,
                    CreatedDate = orderpayment.CreatedDate,
                    PaymentId = order.PaymentId,
                    GrandTotal = orderpayment.GrandTotal,
                  }).ToList();
      var itemcount=data.Count();
      var orders = data.Skip((page - 1) * pageSize).Take(pageSize);
      var paglistdata=new StaticPagedList<OrderModel>(orders,page,pageSize,itemcount);
      pagingmodel.Data = paglistdata;
      pagingmodel.PageSize = pageSize;
      pagingmodel.Page = page;
      pagingmodel.TotalRows = itemcount;
      return pagingmodel;

    }

    public IEnumerable<Order> GetUserOrders(int UserId)
    {
      var data = (from order in _context.Orders join orderitems in _context.OrderItems on order.Id equals orderitems.OrderId select order).ToList();
      return data;
    }
  }
}
