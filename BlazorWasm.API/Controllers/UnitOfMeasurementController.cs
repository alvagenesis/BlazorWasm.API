using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorWasm.API.Data;
using BlazorWasm.Shared;

namespace BlazorWasm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasurementController : ControllerBase

    {
        private protected DataContext _context;

        public UnitOfMeasurementController(DataContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<ActionResult<List<UnitOfMeasurement>>> Update(UnitOfMeasurement updatedUnitOfMeasurement)
        {
            var oldUnitOfMeasurement = await _context.UnitOfMeasurements.FindAsync(updatedUnitOfMeasurement.Id);
            if (oldUnitOfMeasurement is null)
                return NotFound("UnitOfMeasurement not found");

            oldUnitOfMeasurement.Name = updatedUnitOfMeasurement.Name;
            oldUnitOfMeasurement.Status = updatedUnitOfMeasurement.Status;
            oldUnitOfMeasurement.IsActive = updatedUnitOfMeasurement.IsActive;
            oldUnitOfMeasurement.IsSmallestUnit = updatedUnitOfMeasurement.IsSmallestUnit;
            oldUnitOfMeasurement.ConversionToSmallestUnit = updatedUnitOfMeasurement.ConversionToSmallestUnit;

            await _context.SaveChangesAsync();

            return Ok(await _context.UnitOfMeasurements.ToListAsync());
        }
    }
}
