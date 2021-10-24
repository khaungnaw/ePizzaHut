using ePizzaHut.Entity;
using System.Collections.Generic;

namespace ePizzHut.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetUserOrders(int userId);
    }
}
