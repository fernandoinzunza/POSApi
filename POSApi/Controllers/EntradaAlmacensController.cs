using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSApi.Models;

namespace POSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaAlmacensController : ControllerBase
    {
        private readonly POSContext _context;

        public EntradaAlmacensController(POSContext context)
        {
            _context = context;
        }

        // GET: api/EntradaAlmacens
        [HttpGet("GetEntradasAlmacen")]
        public async Task<ActionResult<IEnumerable<EntradaAlmacen>>> GetEntradasAlmacen()
        {
            return await _context.EntradasAlmacen.ToListAsync();
        }

        // GET: api/EntradaAlmacens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntradaAlmacen>> GetEntradaAlmacen(int id)
        {
            var entradaAlmacen = await _context.EntradasAlmacen.FindAsync(id);

            if (entradaAlmacen == null)
            {
                return NotFound();
            }

            return entradaAlmacen;
        }

        // PUT: api/EntradaAlmacens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntradaAlmacen(int id, EntradaAlmacen entradaAlmacen)
        {
            if (id != entradaAlmacen.Id)
            {
                return BadRequest();
            }

            _context.Entry(entradaAlmacen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaAlmacenExists(id))
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

        // POST: api/EntradaAlmacens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AgregarEntrada")]
        public async Task<ActionResult<EntradaAlmacen>> PostEntradaAlmacen([FromBody]JsonElement json)
        {
            var entradaAlmacen = JsonSerializer.Deserialize<EntradaAlmacen>(json.ToString(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            _context.EntradasAlmacen.Add(entradaAlmacen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntradaAlmacen", new { id = entradaAlmacen.Id }, entradaAlmacen);
        }

        // DELETE: api/EntradaAlmacens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntradaAlmacen(int id)
        {
            var entradaAlmacen = await _context.EntradasAlmacen.FindAsync(id);
            if (entradaAlmacen == null)
            {
                return NotFound();
            }

            _context.EntradasAlmacen.Remove(entradaAlmacen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntradaAlmacenExists(int id)
        {
            return _context.EntradasAlmacen.Any(e => e.Id == id);
        }
    }
}
