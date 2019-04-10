using SCApp.Persistance;
using SCApp.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SCApp.Controllers
{
    public class ShopController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Shop
        public async Task<ActionResult> Index()
        {
            var items = db.Items.Include(i => i.Category)
                                .Select(e => new ItemListViewModel
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CategoryName = e.Category.Name,
                                    Price = e.Price
                                }
                                );

            return View(await items.ToListAsync());
        }

        // GET: Cart
        public async Task<ActionResult> Cart()
        {
            var cart = GetShoppingCart();
            return View(cart);
        }

        public void AddToCart(int itemId, int quantity = 1)
        {
            var item = db.Items.Where(e => e.Id == itemId).FirstOrDefault();

            if (item == null)
                throw new ArgumentException("Invalid item");

            var cart = GetShoppingCart();

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
                    Quantity = quantity,
                    UnitPrice = item.Price
                });
            }

            UpdateShoppingCart(cart);
        }

        public async Task<ActionResult> RemoveFromCart(int itemId)
        {
            var cart = GetShoppingCart();

            var cartItem = cart.Items.Where(e => e.ItemId == itemId).FirstOrDefault();

            if (cartItem == null)
                throw new ArgumentException("Invalid item");

            cart.Items.Remove(cartItem);

            UpdateShoppingCart(cart);

            return View("Cart", GetShoppingCart());
        }

        private void UpdateShoppingCart(ShoppingCartViewModel cart)
        {
            Session["cart"] = cart;
        }

        private ShoppingCartViewModel GetShoppingCart()
        {
            ShoppingCartViewModel cart;
            if (Session["cart"] == null)
            {
                cart = new ShoppingCartViewModel();
            }
            else
            {
                cart = (ShoppingCartViewModel)Session["cart"];
            }

            return cart;
        }
    }
}

