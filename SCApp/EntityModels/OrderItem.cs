using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCApp.EntityModels
{
    public class OrderItem : EntityBase
    {
        public Item Item { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}