using ePizzaHut.Entity;
using ePizzHut.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ePizzHut.Repository.Implementations
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDbContext appContext
        {
            get { return _dbContext as AppDbContext; }
        }
        public CartRepository(DbContext dbContext) : base(dbContext) { }
        public Cart GetCart(Guid CartId)
        {
            return appContext.Carts.Include("Items")
                .Where(c=>c.Id == CartId && c.IsActive).FirstOrDefault();
        }

        public int DeleteItem(Guid cartId, int itemId)
        {
            var item = appContext.CartItems.Where(ci => ci.CartId == cartId
            && ci.ItemId == itemId).FirstOrDefault();
            if(item != null)
            {
                appContext.CartItems.Remove(item);
                return appContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int UpdateQuantity(Guid cartId, int itemId, int Quantity)
        {
            bool flag = false;
            var cart = GetCart(cartId);
            if(cart != null)
            {
                foreach(var item in cart.Items)
                {
                    if(item.Id == itemId)
                    {
                        flag = true;
                        if(Quantity <0 && item.Quantity > 1)
                        {
                            item.Quantity += (Quantity);
                        }
                        else if(Quantity > 0)
                        {
                            item.Quantity += (Quantity);
                        }
                    }
                }
            }
            if (flag)
            {
                return appContext.SaveChanges();
            }
            return 0;
        }

        public int UpdateCart(Guid cartId, int userId)
        {
            var cart = GetCart(cartId);
            if (cart != null)
            {
                cart.UserId = userId;
               return appContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
