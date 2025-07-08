using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurismoF.API;
using TurismoF.Data.Data;
using TurismoF.Modelos;

namespace TurismoF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreciosConfiguracionController : ControllerBase
    {
        private readonly Context1 _context;

        public PreciosConfiguracionController(Context1 context)
        {
            _context = context;
        }

        // GET: api/PreciosConfiguracion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrecioConfiguracion>>> GetPrecioConfiguracion()
        {
            return await _context.PreciosConfiguracion.ToListAsync();
        }

        // GET: api/PreciosConfiguracion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrecioConfiguracion>> GetPrecioConfiguracion(int id)
        {
            var precioConfiguracion = await _context.PreciosConfiguracion.FindAsync(id);

            if (precioConfiguracion == null)
            {
                return NotFound();
            }

            return precioConfiguracion;
        }

        // PUT: api/PreciosConfiguracion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrecioConfiguracion(int id, PrecioConfiguracion precioConfiguracion)
        {
            if (id != precioConfiguracion.Id)
            {
                return BadRequest();
            }

            _context.Entry(precioConfiguracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrecioConfiguracionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PreciosConfiguracion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrecioConfiguracion>> PostPrecioConfiguracion(PrecioConfiguracion precioConfiguracion)
        {
            _context.PreciosConfiguracion.Add(precioConfiguracion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrecioConfiguracion", new { id = precioConfiguracion.Id }, precioConfiguracion);
        }

        // DELETE: api/PreciosConfiguracion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrecioConfiguracion(int id)
        {
            var precioConfiguracion = await _context.PreciosConfiguracion.FindAsync(id);
            if (precioConfiguracion == null)
            {
                return NotFound();
            }

            _context.PreciosConfiguracion.Remove(precioConfiguracion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrecioConfiguracionExists(int id)
        {
            return _context.PreciosConfiguracion.Any(e => e.Id == id);
        }
    }
}
