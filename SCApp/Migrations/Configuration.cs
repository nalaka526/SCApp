namespace SCApp.Migrations
{
    using SCApp.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SCApp.Persistance.ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SCApp.Persistance.ShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.ItemCategories.AddOrUpdate(x => x.Id,
                new ItemCategory() { Id = 1, Name = "Item Category 1" },
                new ItemCategory() { Id = 2, Name = "Item Category 2" },
                new ItemCategory() { Id = 3, Name = "Item Category 3" },
                new ItemCategory() { Id = 4, Name = "Item Category 4" },
                new ItemCategory() { Id = 5, Name = "Item Category 5" }
            );

            context.Items.AddOrUpdate(x => x.Id,
                new Item() { Id = 1, Name = "Item 1", Price = 20, CategoryId = 1, IsActive = true },
                new Item() { Id = 1, Name = "Item 2", Price = 100, CategoryId = 2, IsActive = true },
                new Item() { Id = 1, Name = "Item 3", Price = 12500, CategoryId = 5, IsActive = true },
                new Item() { Id = 1, Name = "Item 4", Price = 22, CategoryId = 2, IsActive = true },
                new Item() { Id = 1, Name = "Item 5", Price = 210, CategoryId = 5, IsActive = true },
                new Item() { Id = 1, Name = "Item 6", Price = 70, CategoryId = 2, IsActive = true },
                new Item() { Id = 1, Name = "Item 7", Price = 50, CategoryId = 1, IsActive = true }
            );

        }
    }
}
