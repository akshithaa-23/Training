using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookAPISql.Models
{
  public class BooksCatContext : DbContext
  {
    public BooksCatContext(DbContextOptions<BooksCatContext> options)
        : base(options)
    {
    }

    public DbSet<Books> bookss { get; set; } 
       
   public DbSet<Category> categories { get; set; } = null!;
  }
 
}
