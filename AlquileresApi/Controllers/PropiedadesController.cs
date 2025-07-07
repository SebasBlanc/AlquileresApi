using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlquileresAPI.Context;
using AlquileresAPI.Models;

namespace AlquileresApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropiedadesController : ControllerBase
    {
        private readonly AlquileresContext _context;

        public PropiedadesController(AlquileresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Propiedad>>> ObtenerPropiedades()
        {
            return await _context.Propiedades.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Propiedad>> ObtenerPropiedad(int id)
        {
            var propiedad = await _context.Propiedades.FindAsync(id);
            if (propiedad == null) return NotFound();
            return propiedad;
        }

        [HttpPost]
        public async Task<ActionResult<Propiedad>> PostPropiedad(Propiedad propiedad)
        {
            _context.Propiedades.Add(propiedad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerPropiedad), new { id = propiedad.Id }, propiedad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CrearPropiedad(int id, Propiedad propiedad)
        {
            if (id != propiedad.Id) return BadRequest();

            _context.Entry(propiedad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Propiedades.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPropiedad(int id)
        {
            var propiedad = await _context.Propiedades.FindAsync(id);
            if (propiedad == null) return NotFound();

            _context.Propiedades.Remove(propiedad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
