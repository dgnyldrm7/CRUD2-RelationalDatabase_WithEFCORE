using Microsoft.EntityFrameworkCore;

namespace crud_productList.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
        
        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<ShowCourse> Shows { get; set; } = null!;
    }
}
