using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.IServices
{
  public interface IcartServices:Iservice<Cart>
  {
    bool SaveCart(Cart cart);
  }
}
