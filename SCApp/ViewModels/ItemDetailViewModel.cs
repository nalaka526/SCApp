using SCApp.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCApp.ViewModels
{
    public class ItemDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
    }
}