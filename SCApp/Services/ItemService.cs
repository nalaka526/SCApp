using SCApp.EntityModels;
using SCApp.Persistance;
using SCApp.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SCApp.Services
{
    public class ItemService
    {
        private ShopDbContext _db = new ShopDbContext();

        public async Task AddItem(Item item)
        {
            _db.Items.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ItemListViewModel>> GetAvailableItemsAsync()
        {
            return await _db.Items.Include(i => i.Category)
                                .Where(e=>e.IsActive)
                                .Select(e => new ItemListViewModel
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CategoryName = e.Category.Name,
                                    Price = e.Price
                                }).ToListAsync();
        }
    }
}