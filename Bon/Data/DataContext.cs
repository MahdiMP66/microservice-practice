using BonAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BonAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Models.Bon> Bons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Bon>().HasData(
                new Models.Bon
                {
                    Id = 1,
                    Code= 1001,
                    Off = 10,
                    Created =DateTime.Now
                },
                new Models.Bon
                {
                    Id = 2,
                    Code = 1002,
                    Off = 20,
                    Created = DateTime.Now
                }
                );

        }
    }
}
