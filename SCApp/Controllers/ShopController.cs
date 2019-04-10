using SCApp.Persistance;
using SCApp.Services;
using SCApp.ViewModels;
using System;

using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SCApp.Controllers
{
    public class ShopController : Controller
    {
        private ShopDbContext db = new ShopDbContext();
        private ItemService _itemService = new ItemService();
        private ShoppingCartService _shoppingCartService = new ShoppingCartService();

        // GET: Shop
        public async Task<ActionResult> Index()
        {
            var items = await _itemService.GetAvailableItemsAsync();
            return View(items);
        }

        // GET: Cart
        public async Task<ActionResult> Cart()
        {
            var cart = GetShoppingCart();

            return View(cart);
        }

        public void AddToCart(int itemId)
        {
            var cart = GetShoppingCart();

            cart = _shoppingCartService.AddItemToCart(itemId, cart);

            UpdateShoppingCart(cart);
        }

        public async Task<ActionResult> RemoveFromCart(int itemId)
        {
            var cart = GetShoppingCart();

            _shoppingCartService.RemoveItemFromCart(itemId, ref cart);

            UpdateShoppingCart(cart);

            return RedirectToAction("Cart");
        }

        private void UpdateShoppingCart(ShoppingCartViewModel cart)
        {
            Session["cart"] = cart;
        }

        private ShoppingCartViewModel GetShoppingCart()
        {
            if (Session["cart"] == null)
            {
                return new ShoppingCartViewModel();
            }
            else
            {
                return (ShoppingCartViewModel)Session["cart"];
            }
        }
    }
}

