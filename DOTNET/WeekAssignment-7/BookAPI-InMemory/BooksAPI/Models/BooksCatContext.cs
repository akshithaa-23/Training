using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Models
{
  public class BooksCatContext : DbContext
  {
    public BooksCatContext(DbContextOptions<BooksCatContext> options)
        : base(options)
    {
    }

    public DbSet<Books> bookss { get; set; } = null!;
    public DbSet<Category> categories { get; set; } = null!;
  }
 
}
