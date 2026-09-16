using ItemToExcel.Data.AppDbContext;
using ItemToExcel.Data.Dto;
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
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return await _context.Items.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == item.Id);
        }

        public async Task DeleteItemAsync(int id)
        {
            var del = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (del == null) throw new KeyNotFoundException();
            _context.Items.Remove(del);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var items = await _context.Items.Include(x => x.Category).AsNoTracking().ToListAsync(); // Need to eagerly load the category so we can see the category in the response
            return items;
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            var item = await _context.Items.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id); // Need to eagerly load the category so we can see the category in the response
            if (item == null) throw new KeyNotFoundException();
            return item;
        }

        public async Task UpdateItemAsync(int id, ItemCreateDTO item)
        {
            var itemToBeUpdated = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (itemToBeUpdated == null) throw new KeyNotFoundException("Couldnt find item");

            itemToBeUpdated.Name = item.Name;
            itemToBeUpdated.BeforeDiscount = item.beforeDiscount;
            itemToBeUpdated.AfterDiscount = item.afterDiscount;
            itemToBeUpdated.CategoryId = item.catID;
            await _context.SaveChangesAsync();
        }
    }
}
