using Microsoft.AspNetCore.Mvc;
using CrudLatest.Server.Services;
using CrudLatest.Server.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudLatest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMongoDbService _mongoDbService;

        public ItemsController(IMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            return await _mongoDbService.GetItemsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(string id)
        {
            var item = await _mongoDbService.GetItemByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Item item)
        {
            await _mongoDbService.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(string id, Item item)
        {
            await _mongoDbService.UpdateItemAsync(id, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            await _mongoDbService.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
