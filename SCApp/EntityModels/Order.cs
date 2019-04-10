using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCApp.EntityModels
{
    public class Order : EntityBase
    {
        public string CustomerName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}