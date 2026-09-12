using ItemToExcel.Data.Model;

namespace ItemToExcel.Repository
{
    public interface IItemRepository
    {
        public Task<IEnumerable<Item>> GetAllAsync();

        public Task<Item> GetByIdAsync(int id);
        public Task<Item> AddItemAsync(Item item);
        public Task<Item> UpdateItemAsync(int id, Item item);
        public Task<Item> DeleteItemAsync(int id);
    }
}
