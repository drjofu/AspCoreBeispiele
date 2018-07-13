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
    public class KursController : ControllerBase
    {
        private readonly KursverwaltungContext _context;

        public KursController(KursverwaltungContext context)
        {
            _context = context;
        }

        // GET: api/Kurs
        [HttpGet]
        public IEnumerable<Kurs> GetKurs()
        {
            return _context.Kurs;
        }

        // GET: api/Kurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kurs>> GetKurs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kurs = await _context.Kurs.FindAsync(id);

            if (kurs == null)
            {
                return NotFound();
            }

            return Ok(kurs);
        }

        // PUT: api/Kurs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKurs([FromRoute] int id, [FromBody] Kurs kurs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kurs.Id)
            {
                return BadRequest();
            }

            _context.Entry(kurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KursExists(id))
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

        // POST: api/Kurs
        [HttpPost]
        public async Task<IActionResult> PostKurs([FromBody] Kurs kurs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Kurs.Add(kurs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKurs", new { id = kurs.Id }, kurs);
        }

        // DELETE: api/Kurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKurs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kurs = await _context.Kurs.FindAsync(id);
            if (kurs == null)
            {
                return NotFound();
            }

            _context.Kurs.Remove(kurs);
            await _context.SaveChangesAsync();

            return Ok(kurs);
        }

        private bool KursExists(int id)
        {
            return _context.Kurs.Any(e => e.Id == id);
        }
    }
}