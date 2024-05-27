using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;
using System.Reflection;


namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<User>               //DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //ilgili tablolar, migrations oluşur
            //modelBuilder.ApplyConfiguration(new HouseConfig());
            //modelBuilder.ApplyConfiguration(new RoleConfiguration()); //tek tek yazmak yerine assembly üzerinden de alınabilir

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
