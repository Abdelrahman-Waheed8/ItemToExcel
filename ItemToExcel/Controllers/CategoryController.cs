using ItemToExcel.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ItemToExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return Ok(categories);
        }
    }
}
