using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace POSApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly POSContext _context;

        public ArticulosController(POSContext context)
        {
            _context = context;
        }

        // GET: api/Articulos
        [HttpGet("GetArticulos")]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos()
        {
            return await _context.Articulos.ToListAsync();
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo(string id)
        {
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // PUT: api/Articulos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(string id, Articulo articulo)
        {
            if (id != articulo.Clave)
            {
                return BadRequest();
            }

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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

        // POST: api/Articulos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PostArticulo([FromBody] Articulo obj)
        {

            _context.Articulos.Add(obj);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArticuloExists(obj.Clave))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArticulo", new { id = obj.Clave }, obj);
        }
        [HttpPost("Agregar")]
        [Produces("application/json")]
        public async Task<ActionResult<Articulo>> AgregarArticulo([FromBody] JsonElement obj)
        {

            var articulo = JsonSerializer.Deserialize<Articulo>(obj.ToString());
            _context.Articulos.Add(articulo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArticuloExists(articulo.Clave))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArticulo", new { id = articulo.Clave }, articulo);
        }
        // DELETE: api/Articulos/5
        [HttpPost("EliminarArticulo")]
        public async Task<ActionResult<Articulo>> DeleteArticulo(JsonElement art)
        {
            var aux = JsonSerializer.Deserialize<Articulo>(art.ToString());
            var articulo = await _context.Articulos.FindAsync(aux.Clave);
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return articulo;
        }
        [HttpPost("UpdateArticulo")]
        public async Task<ActionResult<Articulo>> UpdateArticulo([FromBody] JsonElement articulo)
        {
            var art = JsonSerializer.Deserialize<Articulo>(articulo.ToString(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            var existe = await _context.Articulos.FindAsync(art.Clave);
            if (existe == null)
            {
                return NotFound();
            }
            existe.Departamento = art.Departamento;
            existe.Descripcion = art.Descripcion;
            existe.PrecioAlCosto = art.PrecioAlCosto;
            existe.PrecioMayoreo = art.PrecioMayoreo;
            existe.PrecioPublico = art.PrecioPublico;
            existe.PrecioSecundario = art.PrecioSecundario;
            existe.Stock = art.Stock;
            existe.Unidad = art.Unidad;
            existe.TipoUnidad = art.TipoUnidad;
            await _context.SaveChangesAsync();
            return Ok(existe);
        }
        [HttpPost("GetArticulosDep")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulosDep([FromBody] JsonElement json)
        {
            var dep = JsonSerializer.Deserialize<Departamento>(json.ToString(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return await _context.Articulos.Where(b => b.Departamento == dep.Nombre).ToListAsync();
        }

        private bool ArticuloExists(string id)
        {
            return _context.Articulos.Any(e => e.Clave == id);
        }
    }
}
