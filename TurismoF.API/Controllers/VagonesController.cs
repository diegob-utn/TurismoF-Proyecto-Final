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
    public class VagonesController : ControllerBase
    {
        private readonly Context1 _context;

        public VagonesController(Context1 context)
        {
            _context = context;
        }

        // GET: api/Vagones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vagon>>> GetVagon()
        {
            return await _context.Vagones.ToListAsync();
        }

        // GET: api/Vagones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vagon>> GetVagon(int id)
        {
            var vagon = await _context.Vagones.FindAsync(id);

            if (vagon == null)
            {
                return NotFound();
            }

            return vagon;
        }

        // PUT: api/Vagones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVagon(int id, Vagon vagon)
        {
            if (id != vagon.Id)
            {
                return BadRequest();
            }

            _context.Entry(vagon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagonExists(id))
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

        // POST: api/Vagones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vagon>> PostVagon(Vagon vagon)
        {
            _context.Vagones.Add(vagon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVagon", new { id = vagon.Id }, vagon);
        }

        // DELETE: api/Vagones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVagon(int id)
        {
            var vagon = await _context.Vagones.FindAsync(id);
            if (vagon == null)
            {
                return NotFound();
            }

            _context.Vagones.Remove(vagon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VagonExists(int id)
        {
            return _context.Vagones.Any(e => e.Id == id);
        }
    }
}
