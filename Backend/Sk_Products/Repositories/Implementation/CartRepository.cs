using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using Repositories.IRepository;

namespace Repositories.Implementation
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        private Sk_productContext dbContext
        {
            get
            {
                return _dbContext as Sk_productContext;
            }
        }

        public CartRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public bool SaveCart(Cart cart)
        {
            cart.CreatedDate = DateTime.Now;
            dbContext.Carts.Add(cart);
            dbContext.SaveChanges();
            return true;
        }
    }
}
