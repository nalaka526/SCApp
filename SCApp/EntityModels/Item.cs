using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCApp.EntityModels
{
    public class Item : EntityBase
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual ItemCategory Category { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}