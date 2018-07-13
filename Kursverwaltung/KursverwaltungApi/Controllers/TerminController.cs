using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kursverwaltung.Models;

namespace KursverwaltungApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminController : ControllerBase
    {
        private readonly KursverwaltungContext _context;

        public TerminController(KursverwaltungContext context)
        {
            _context = context;
        }

        // GET: api/Termin
        [HttpGet]
        public IEnumerable<Termin> GetTermin()
        {
            return _context.Termin;
        }

        // GET: api/Termin/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTermin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var termin = await _context.Termin.FindAsync(id);

            if (termin == null)
            {
                return NotFound();
            }

            return Ok(termin);
        }

        // PUT: api/Termin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTermin([FromRoute] int id, [FromBody] Termin termin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != termin.Id)
            {
                return BadRequest();
            }

            _context.Entry(termin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerminExists(id))
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

        // POST: api/Termin
        [HttpPost]
        public async Task<IActionResult> PostTermin([FromBody] Termin termin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Termin.Add(termin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTermin", new { id = termin.Id }, termin);
        }

        // DELETE: api/Termin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTermin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var termin = await _context.Termin.FindAsync(id);
            if (termin == null)
            {
                return NotFound();
            }

            _context.Termin.Remove(termin);
            await _context.SaveChangesAsync();

            return Ok(termin);
        }

        private bool TerminExists(int id)
        {
            return _context.Termin.Any(e => e.Id == id);
        }
    }
}