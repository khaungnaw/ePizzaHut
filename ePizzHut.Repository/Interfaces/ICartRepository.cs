using ePizzaHut.Entity;
using System;

namespace ePizzHut.Repository.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        public Cart GetCart(Guid CartId);
        int DeleteItem(Guid cartId, int itemId);
        int UpdateQuantity(Guid cartId, int itemId, int Quantity);
        int UpdateCart(Guid cartId, int userId);
    }
}
