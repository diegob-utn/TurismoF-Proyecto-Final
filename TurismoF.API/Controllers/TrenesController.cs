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
    public class TrenesController : ControllerBase
    {
        private readonly Context1 _context;

        public TrenesController(Context1 context)
        {
            _context = context;
        }

        // GET: api/Trenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tren>>> GetTren()
        {
            return await _context.Trenes.ToListAsync();
        }

        // GET: api/Trenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tren>> GetTren(int id)
        {
            var tren = await _context.Trenes.FindAsync(id);

            if (tren == null)
            {
                return NotFound();
            }

            return tren;
        }

        // PUT: api/Trenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTren(int id, Tren tren)
        {
            if (id != tren.Id)
            {
                return BadRequest();
            }

            _context.Entry(tren).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrenExists(id))
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

        // POST: api/Trenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tren>> PostTren(Tren tren)
        {
            _context.Trenes.Add(tren);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTren", new { id = tren.Id }, tren);
        }

        // DELETE: api/Trenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTren(int id)
        {
            var tren = await _context.Trenes.FindAsync(id);
            if (tren == null)
            {
                return NotFound();
            }

            _context.Trenes.Remove(tren);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrenExists(int id)
        {
            return _context.Trenes.Any(e => e.Id == id);
        }
    }
}
