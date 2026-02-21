using Microsoft.EntityFrameworkCore;

namespace Student.Data
{
    public class StudentContext :DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
        public DbSet<Student.Models.Stds> Students { get; set; }
    }
}
