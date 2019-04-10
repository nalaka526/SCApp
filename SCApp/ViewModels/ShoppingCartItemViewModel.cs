using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCApp.ViewModels
{
    public class ShoppingCartItemViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal
        {
            get { return UnitPrice * Quantity; }
        }

    }
}