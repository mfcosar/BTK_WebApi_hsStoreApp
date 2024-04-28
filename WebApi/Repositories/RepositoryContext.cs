using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
