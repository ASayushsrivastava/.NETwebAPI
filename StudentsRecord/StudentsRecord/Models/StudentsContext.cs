using Microsoft.EntityFrameworkCore;

namespace StudentsRecord.Models
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options)
        : base(options)
        {
        }

        public DbSet<StudentsData> StudentsDatas { get; set; } = null!;
    }
}
