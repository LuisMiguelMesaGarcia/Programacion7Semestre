using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ecommerce.Models;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicidadsController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public PublicidadsController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Publicidads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publicidad>>> GetPublicidads()
        {
            return await _context.Publicidads.ToListAsync();
        }

        // GET: api/Publicidads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publicidad>> GetPublicidad(int id)
        {
            var publicidad = await _context.Publicidads.FindAsync(id);

            if (publicidad == null)
            {
                return NotFound();
            }

            return publicidad;
        }

        // PUT: api/Publicidads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicidad(int id, Publicidad publicidad)
        {
            if (id != publicidad.IdPublicidad)
            {
                return BadRequest();
            }

            _context.Entry(publicidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicidadExists(id))
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

        // POST: api/Publicidads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publicidad>> PostPublicidad(Publicidad publicidad)
        {
            _context.Publicidads.Add(publicidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicidad", new { id = publicidad.IdPublicidad }, publicidad);
        }

        // DELETE: api/Publicidads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicidad(int id)
        {
            var publicidad = await _context.Publicidads.FindAsync(id);
            if (publicidad == null)
            {
                return NotFound();
            }

            _context.Publicidads.Remove(publicidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicidadExists(int id)
        {
            return _context.Publicidads.Any(e => e.IdPublicidad == id);
        }
    }
}
