using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlquileresAPI.Context;
using AlquileresAPI.Models;

namespace AlquileresApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlquilerController : ControllerBase
    {
        private readonly AlquileresContext _context;

        public AlquilerController(AlquileresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alquiler>>> ObtnerAlquileres()
        {
            return await _context.Alquileres.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alquiler>> GetAlquiler(int id)
        {
            var alquiler = await _context.Alquileres.FindAsync(id);
            if (alquiler == null) return NotFound();
            return alquiler;
        }

        [HttpPost]
        public async Task<ActionResult<Alquiler>> EditarAlquiler(Alquiler alquiler)
        {
            _context.Alquileres.Add(alquiler);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlquiler), new { id = alquiler.Id }, alquiler);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CrearAlquiler(int id, Alquiler alquiler)
        {
            if (id != alquiler.Id) return BadRequest();

            _context.Entry(alquiler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Alquileres.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarAlquiler(int id)
        {
            var alquiler = await _context.Alquileres.FindAsync(id);
            if (alquiler == null) return NotFound();

            _context.Alquileres.Remove(alquiler);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

