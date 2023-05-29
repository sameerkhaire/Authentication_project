
using DAL.Models;
using Repositories.IRepository;
using Services.Interfaces;
using Services.ServiceInterface;

namespace Services.serviceImplemenation
{
    public class CartService : Service<Cart>, ICartService
    {
        private readonly ICartRepository _cartRepo;
        public CartService(ICartRepository cartRepo): base(cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public bool SaveCart(Cart cart)
        {
            return _cartRepo.SaveCart(cart);
        }
    }
}
