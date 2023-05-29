

using DAL.Models;

namespace Services.ServiceInterface
{
    public interface ICartService: IService<Cart>
    {
        bool SaveCart(Cart cart);
    }
}
