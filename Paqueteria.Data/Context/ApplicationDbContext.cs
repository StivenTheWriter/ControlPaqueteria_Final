using Microsoft.EntityFrameworkCore;
using Paqueteria.Domain.Entities;

namespace Paqueteria.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Residente> Residentes { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}