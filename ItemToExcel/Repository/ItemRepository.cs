using ItemToExcel.Data.AppDbContext;
using ItemToExcel.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ItemToExcel.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Item> AddItemAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> DeleteItemAsync(int id)
        {
            var del = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (del == null) throw new KeyNotFoundException();
            _context.Items.Remove(del);
            await _context.SaveChangesAsync();
            return del;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var items = await _context.Items.AsNoTracking().ToListAsync();
            return items;
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            var item = await _context.Items.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) throw new KeyNotFoundException();
            return item;
        }

        public async Task<Item> UpdateItemAsync(int id, Item item)
        {
            var itemToBeUpdated = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (itemToBeUpdated == null) throw new KeyNotFoundException("Couldnt find item");

            itemToBeUpdated.Id = item.Id;
            itemToBeUpdated.Name = item.Name;
            itemToBeUpdated.BeforeDiscount = item.BeforeDiscount;
            itemToBeUpdated.AfterDiscount = item.AfterDiscount;
            itemToBeUpdated.CategoryId = item.CategoryId;
            await _context.SaveChangesAsync();
            return itemToBeUpdated;
        }
    }
}
