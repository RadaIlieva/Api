using Microsoft.EntityFrameworkCore;
using ApiCSV.DB.DTO;

namespace CSVReadAndSaveInDB.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApiCSV.DB.DTO.CsvDataDto> CsvData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiCSV.DB.DTO.CsvDataDto>()
                .HasKey(e => e.OrganizationId);
        }
    }
}
