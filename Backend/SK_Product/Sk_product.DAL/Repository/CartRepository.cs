using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.DAL.Repository
{
  public class CartRepository : BaseRepository<Cart>, IcartRepo
  {
    private readonly Sk_productContext _context;
    public CartRepository(Sk_productContext context) : base(context)
    {
      _context = context;
    }

    public bool SaveCart(Cart cart)
    {
      cart.CreatedDate = DateTime.Now;
      _context.Add(cart);
      _context.SaveChanges();
      return true;
    }
  }
}
