using Microsoft.EntityFrameworkCore;

namespace ApiCSV.CsvServicesAndDb.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DTO.CsvDataDto> CsvData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTO.CsvDataDto>()
                .HasKey(e => e.OrganizationId);
        }
    }
}
