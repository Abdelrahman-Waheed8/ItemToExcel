using ItemToExcel.Data.AppDbContext;
using ItemToExcel.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ItemToExcel.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }
    }
}
