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
    public class DescuentosPermitidosController : ControllerBase
    {
        private readonly POSContext _context;

        public DescuentosPermitidosController(POSContext context)
        {
            _context = context;
        }

        // GET: api/DescuentosPermitidos
        [HttpGet("GetDescPermitidos")]
        public async Task<ActionResult<IEnumerable<DescuentoPermitido>>> GetDescuentosPermitidos()
        {
            return await _context.DescuentosPermitidos.ToListAsync();
        }

        // GET: api/DescuentosPermitidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DescuentoPermitido>> GetDescuentoPermitido(int id)
        {
            var descuentoPermitido = await _context.DescuentosPermitidos.FindAsync(id);

            if (descuentoPermitido == null)
            {
                return NotFound();
            }

            return descuentoPermitido;
        }

        // PUT: api/DescuentosPermitidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescuentoPermitido(int id, DescuentoPermitido descuentoPermitido)
        {
            if (id != descuentoPermitido.IdPermiso)
            {
                return BadRequest();
            }

            _context.Entry(descuentoPermitido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescuentoPermitidoExists(id))
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

        // POST: api/DescuentosPermitidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AgregarDescPermitido/{id:int}")]
        public async Task<ActionResult<DescuentoPermitido>> PostDescuentoPermitido(int id,[FromBody] JsonElement json)
        {
            try
            {
                var arreglo = json.EnumerateArray();
                var diccionario = new Dictionary<Usuario, Seleccionado>();
                foreach (var a in arreglo)
                {
                    var usuario = JsonSerializer.Deserialize<Usuario>(a.GetProperty("Key").ToString(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    var seleccionado = JsonSerializer.Deserialize<Seleccionado>(a.GetProperty("Value").ToString(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    diccionario.Add(usuario, seleccionado);
                }                              
                if (diccionario.Count > 0)
                {
                    foreach (var dp in diccionario)
                    {
                        var usuario = dp.Key;

                        if (dp.Value.Permitido)
                        {
                            var nuevoDescPermitido = new DescuentoPermitido { NoEmpleado = usuario.NoEmpleado, IdDescuento = id };
                            _context.DescuentosPermitidos.Add(nuevoDescPermitido);
                            
                        }
                    }
                    await _context.SaveChangesAsync();

                    return Ok("Agregados");
                }
                else
                {
                    return Ok("Ninguno seleccionado");
                }
                 
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
               
           
            
        }

        // DELETE: api/DescuentosPermitidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescuentoPermitido(int id)
        {
            var descuentoPermitido = await _context.DescuentosPermitidos.FindAsync(id);
            if (descuentoPermitido == null)
            {
                return NotFound();
            }

            _context.DescuentosPermitidos.Remove(descuentoPermitido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DescuentoPermitidoExists(int id)
        {
            return _context.DescuentosPermitidos.Any(e => e.IdPermiso == id);
        }
    }
}
