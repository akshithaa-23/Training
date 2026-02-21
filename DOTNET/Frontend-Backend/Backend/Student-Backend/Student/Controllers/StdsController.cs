using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Data;
using Student.Models;

namespace Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StdsController : ControllerBase
    {
        private readonly StudentContext _context;

        public StdsController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Stds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stds>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Stds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stds>> GetStds(int id)
        {
            var stds = await _context.Students.FindAsync(id);

            if (stds == null)
            {
                return NotFound();
            }

            return stds;
        }

        // PUT: api/Stds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStds(int id, Stds stds)
        {
            if (id != stds.Id)
            {
                return BadRequest();
            }

            _context.Entry(stds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StdsExists(id))
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

        // POST: api/Stds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stds>> PostStds(Stds stds)
        {
            _context.Students.Add(stds);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStds", new { id = stds.Id }, stds);
        }

        // DELETE: api/Stds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStds(int id)
        {
            var stds = await _context.Students.FindAsync(id);
            if (stds == null)
            {
                return NotFound();
            }

            _context.Students.Remove(stds);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StdsExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
