using ItemToExcel.Data.AppDbContext;
using ItemToExcel.Data.Model;

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
            throw new NotImplementedException();
        }

        public async Task<Item> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) throw new KeyNotFoundException();
            return item;
        }

        public async Task<Item> UpdateItemAsync(int id, Item item)
        {
            throw new NotImplementedException();
        }
    }
}
