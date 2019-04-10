using System.Collections.Generic;
using System.Linq;

namespace SCApp.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            Items = new List<ShoppingCartItemViewModel>();
        }

        public List<ShoppingCartItemViewModel> Items { get; set; }

        public decimal Total
        {
            get { return Items.Sum(e => e.LineTotal); }
        }

    }
}