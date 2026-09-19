using ItemToExcel.Data.Model;

namespace ItemToExcel.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
