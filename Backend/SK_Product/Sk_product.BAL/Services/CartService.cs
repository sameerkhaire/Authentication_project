using Sk_product.BAL.IServices;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.Services
{
  public class CartService : Service<Cart>, IcartServices
  {
    private readonly IcartRepo _cartrepository;
    public CartService(IcartRepo cartrepo, IBaseRepository<Cart> repository) : base(repository)
    {
      _cartrepository=cartrepo;
    }

    public bool SaveCart(Cart cart)
    {
     return _cartrepository.SaveCart(cart);

    }
  }
}
