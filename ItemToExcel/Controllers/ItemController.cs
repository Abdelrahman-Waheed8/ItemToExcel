using ItemToExcel.Data.AppDbContext;
using ItemToExcel.Data.Dto;
using ItemToExcel.Data.Model;
using ItemToExcel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemToExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepo;
        private readonly AppDbContext _db;
        public ItemController(IItemRepository itemRepo, AppDbContext db)
        {
            _itemRepo = itemRepo;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _itemRepo.GetAllAsync();
            var response = items.Select(i => new ItemResponseDTO(
                i.Id, i.Name, i.BeforeDiscount, i.AfterDiscount, i.CategoryId, i.Category.Name
            ));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await _itemRepo.GetByIdAsync(id);
            var response = new ItemResponseDTO
                (item.Id, item.Name, item.BeforeDiscount, item.AfterDiscount, item.CategoryId, item.Category.Name);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody]ItemCreateDTO itemDTO)
        {
            var item = new Item
            {
                Name = itemDTO.Name,
                BeforeDiscount = itemDTO.beforeDiscount,
                AfterDiscount = itemDTO.afterDiscount,
                CategoryId = itemDTO.catID
            };
            var added = await _itemRepo.AddItemAsync(item);
            var response = new ItemResponseDTO(added.Id,added.Name,added.BeforeDiscount,added.AfterDiscount,added.CategoryId,added.Category.Name);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatedItem(int id, [FromBody] ItemCreateDTO itemdto)
        {
            var updated = await _itemRepo.UpdateItemAsync(id, itemdto);
            var response = new ItemResponseDTO(updated.Id, updated.Name, updated.BeforeDiscount, updated.AfterDiscount, updated.CategoryId, updated.Category.Name);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _itemRepo.DeleteItemAsync(id);
            return Ok();
        }
    }
}
