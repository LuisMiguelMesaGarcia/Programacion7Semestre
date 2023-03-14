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
    public class CarritoComprasController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public CarritoComprasController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/CarritoCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarritoCompra>>> GetCarritoCompras()
        {
            return await _context.CarritoCompras.ToListAsync();
        }

        // GET: api/CarritoCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoCompra>> GetCarritoCompra(int id)
        {
            var carritoCompra = await _context.CarritoCompras.FindAsync(id);

            if (carritoCompra == null)
            {
                return NotFound();
            }

            return carritoCompra;
        }

        // PUT: api/CarritoCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarritoCompra(int id, CarritoCompra carritoCompra)
        {
            if (id != carritoCompra.IdCarrito)
            {
                return BadRequest();
            }

            _context.Entry(carritoCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoCompraExists(id))
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

        // POST: api/CarritoCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarritoCompra>> PostCarritoCompra(CarritoCompra carritoCompra)
        {
            _context.CarritoCompras.Add(carritoCompra);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarritoCompraExists(carritoCompra.IdCarrito))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarritoCompra", new { id = carritoCompra.IdCarrito }, carritoCompra);
        }

        // DELETE: api/CarritoCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarritoCompra(int id)
        {
            var carritoCompra = await _context.CarritoCompras.FindAsync(id);
            if (carritoCompra == null)
            {
                return NotFound();
            }

            _context.CarritoCompras.Remove(carritoCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarritoCompraExists(int id)
        {
            return _context.CarritoCompras.Any(e => e.IdCarrito == id);
        }
    }
}
