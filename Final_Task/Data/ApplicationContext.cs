using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Task.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Task.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<Version> Versions { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Version>()
                .HasOne(p => p.Material)
                .WithMany(t => t.Versions)
                .HasForeignKey(p => p.MaterialId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
