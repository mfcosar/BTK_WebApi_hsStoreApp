using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Config;

namespace WebApi.Repositories
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HouseConfig());
        }
    }
}
