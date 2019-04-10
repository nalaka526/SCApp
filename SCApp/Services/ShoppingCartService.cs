using SCApp.Persistance;
using SCApp.ViewModels;
using System;
using System.Linq;

namespace SCApp.Services
{
    public class ShoppingCartService
    {
        private ShopDbContext _db = new ShopDbContext();

        public ShoppingCartViewModel AddItemToCart(int itemId, ShoppingCartViewModel cart)
        {
            var item = _db.Items.Where(e => e.Id == itemId).FirstOrDefault();

            if (item == null)
            {
                throw new ArgumentException("Invalid item");
            }

            var cartItem = cart.Items.Where(e => e.ItemId == itemId).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Items.Add(new ShoppingCartItemViewModel()
                {
                    ItemId = item.Id,
                    ItemName = item.Name,
                    Quantity = 1,
                    UnitPrice = item.Price
                });
            }

            return cart;
        }

        public ShoppingCartViewModel RemoveItemFromCart(int itemId, ref ShoppingCartViewModel cart)
        {
            var cartItem = cart.Items.Where(e => e.ItemId == itemId).FirstOrDefault();

            if (cartItem == null)
            {
                throw new ArgumentException("Invalid item");
            }

            cart.Items.Remove(cartItem);

            return cart;
        }
    }
}