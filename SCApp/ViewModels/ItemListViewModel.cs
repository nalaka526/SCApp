using SCApp.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCApp.ViewModels
{
    public class ItemListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
    }
}