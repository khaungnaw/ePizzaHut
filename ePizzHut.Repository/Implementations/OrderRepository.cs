using ePizzaHut.Entity;
using ePizzHut.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ePizzHut.Repository.Implementations
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext) : base(dbContext) { }
        private AppDbContext appContext
        {
            get { return _dbContext as AppDbContext; }
        }

        public IEnumerable<Order> GetUserOrders(int userId)
        {
            return appContext.Orders
                .Include(o=>o.OrderItems)
                .Where(x=>x.UserId == userId);
        }
    }
}
