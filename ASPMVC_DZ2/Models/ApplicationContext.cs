using Microsoft.EntityFrameworkCore;

namespace ASPMVC_DZ2.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Models.City> Cities { get; set; }
        public DbSet<Models.Area> Areas { get; set; }

        private string sqlConnectionString = @"Server=(localdb)\mssqllocaldb;Database=aspnet-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(sqlConnectionString);
        }
    }
}
