using Microsoft.EntityFrameworkCore;
using StudentsrecordMVC.Models;

namespace StudentsrecordMVC.Context
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> contextOptions) : base(contextOptions) 
        { 
        
        }

        public DbSet<Student> Students { get; set; }
    }
}
