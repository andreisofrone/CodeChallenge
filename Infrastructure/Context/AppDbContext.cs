using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Infrastructure.Context
{
    public class AppDbContext
       : DbContext
    {
        private AppSettings configuration { get; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<AppSettings> configuration)
            : base(options)
        {
            this.configuration = configuration?.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
