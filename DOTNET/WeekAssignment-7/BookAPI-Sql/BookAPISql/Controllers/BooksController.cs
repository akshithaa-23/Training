using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAPISql.Models;

namespace BookAPISql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksCatContext _context;

        public BooksController(BooksCatContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> Getbookss()
        {
            return await _context.bookss.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBooks(int id)
        {
            var books = await _context.bookss.FindAsync(id);

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooks(int id, Books books)
        {
            if (id != books.BookId)
            {
                return BadRequest();
            }

            _context.Entry(books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
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

        [HttpGet("grouped-by-category")]
        public async Task<IActionResult> GetGroupedByCategory()
        {
            var result = await _context.bookss
                .Include(p => p.Category)
                .GroupBy(p => p.Category.CategoryName)
                .Select(g => new
                {
                    Category = g.Key,
                    Products = g.Select(p => new
                    {
                        p.BookId,
                        p.BookName,
                        p.BookPrice
                    })
                })
                .ToListAsync();

            return Ok(result);
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Books>> PostBooks(Books books)
        {
            _context.bookss.Add(books);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooks", new { id = books.BookId }, books);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooks(int id)
        {
            var books = await _context.bookss.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            _context.bookss.Remove(books);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BooksExists(int id)
        {
            return _context.bookss.Any(e => e.BookId == id);
        }
    }
}
