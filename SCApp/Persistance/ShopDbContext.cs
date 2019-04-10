using Microsoft.AspNet.Identity.EntityFramework;
using SCApp.EntityModels;
using SCApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SCApp.Persistance
{
    public class ShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public ShopDbContext() : base("name=DefaultConnection")
        {

        }

        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}