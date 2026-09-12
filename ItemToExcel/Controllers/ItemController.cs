using ItemToExcel.Data.Dto;
using ItemToExcel.Data.Model;
using ItemToExcel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemToExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepo;
        public ItemController(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _itemRepo.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await _itemRepo.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemCreateDTO itemDTO)
        {
            var item = new Item
            {
                Name = itemDTO.Name,
                BeforeDiscount = itemDTO.beforeDiscount,
                AfterDiscount = itemDTO.afterDiscount,
                CategoryId = itemDTO.catID
            };

            var created = await _itemRepo.AddItemAsync(item);
            var response = new ItemResponseDTO
            (
                created.Id,
                created.Name,
                created.BeforeDiscount,
                created.AfterDiscount,
                itemDTO.catID,
                null
            );
            return Ok(response);
        }
    }
}
