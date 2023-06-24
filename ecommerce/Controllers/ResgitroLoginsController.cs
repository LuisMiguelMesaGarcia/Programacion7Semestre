using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ecommerce.Models;
using ecommerce.ModelViews;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResgitroLoginsController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public ResgitroLoginsController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/ResgitroLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroLogMV>>> GetResgitroLogins()
        {
            var query = _context.ResgitroLogins.Join(_context.Usuarios, reglog => reglog.IdUsuarioFk, usu => usu.IdUsuario, (reglog, usu) => new RegistroLogMV
            {
                IdRegistroLogin = reglog.IdRegistroLogin,
                Email = usu.Email,
                Fecha = reglog.Fecha,
                Detalle = reglog.Detalle
            });
            return Ok(query);
        }

        // GET: api/ResgitroLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResgitroLogin>> GetResgitroLogin(int id)
        {
            var resgitroLogin = await _context.ResgitroLogins.FindAsync(id);

            if (resgitroLogin == null)
            {
                return NotFound();
            }

            return resgitroLogin;
        }

        // PUT: api/ResgitroLogins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResgitroLogin(int id, ResgitroLogin resgitroLogin)
        {
            if (id != resgitroLogin.IdRegistroLogin)
            {
                return BadRequest();
            }

            _context.Entry(resgitroLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResgitroLoginExists(id))
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

        // POST: api/ResgitroLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResgitroLogin>> PostResgitroLogin(ResgitroLogin resgitroLogin)
        {
            _context.ResgitroLogins.Add(resgitroLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResgitroLogin", new { id = resgitroLogin.IdRegistroLogin }, resgitroLogin);
        }

        // DELETE: api/ResgitroLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResgitroLogin(int id)
        {
            var resgitroLogin = await _context.ResgitroLogins.FindAsync(id);
            if (resgitroLogin == null)
            {
                return NotFound();
            }

            _context.ResgitroLogins.Remove(resgitroLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResgitroLoginExists(int id)
        {
            return _context.ResgitroLogins.Any(e => e.IdRegistroLogin == id);
        }
    }
}
