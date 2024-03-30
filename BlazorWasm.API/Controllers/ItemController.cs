using BlazorWasm.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorWasm.API.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
        
    {
        private protected DataContext _context;

        public ItemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetAll ()
        {
            var items =  await _context.Items.Include(x => x.UnitOfMeasurements).ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            var result = await _context.Items.FindAsync(id);
             
            if (result == null)            
                return NotFound("Item not found");
            return Ok(result);            
        }


        [HttpPost]
        public async Task<ActionResult<List<Item>>> Add(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Items.Include(x => x.UnitOfMeasurements).ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Item>>> Update(Item updatedItem)
        {
            var oldItem = await _context.Items.FindAsync(updatedItem.Id);
            if (oldItem is null)
                return NotFound("Item not found");
            
            oldItem.Code = updatedItem.Code;
            oldItem.Description= updatedItem.Description;
            oldItem.Status = updatedItem.Status;
            oldItem.IsActive = updatedItem.IsActive;

            await _context.SaveChangesAsync();            

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> Delete(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item is null)
                return NotFound("Item not found");         
           
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();            

            return Ok(item);
        }

    }
}
