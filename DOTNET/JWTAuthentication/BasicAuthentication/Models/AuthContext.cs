using Microsoft.EntityFrameworkCore;

namespace BasicAuthentication.Models
{
    public class AuthContext :DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    
    }
}
