using DAL.Models;
using Repositories.Interface;

namespace Repositories.IRepository
{
    public interface ICartRepository : IBaseRepo<Cart>
    {
        bool SaveCart(Cart cart);
    }
}
