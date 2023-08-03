using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.Data
{
    public class DataContext: DbContext
    {
        public readonly IConfiguration _configuration;
        public DataContext(DbContextOptions opt): base(opt) { }

        public DbSet<Inspection> Inspections { get; set;}
        public DbSet<InspectionType> InspectionTypes { get; set;}
        public DbSet<Estado> Estados { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Inspection>()
                .Property(inspection => inspection.Id)
                .IsRequired();
            modelBuilder.Entity<InspectionType>()
                .Property(inspectionType => inspectionType.Id)
                .IsRequired();
            modelBuilder.Entity<Estado>()
                .Property(estado => estado.Id)
                .IsRequired();
        }
    }
}
