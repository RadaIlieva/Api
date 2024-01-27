using ApiCSV.CsvServicesAndDb.DB.DTO;
using ApiCSV.CsvServicesAndDb.DB;
using ApiCSV.CsvServicesAndDb.Services.Interface;
using EFCore.BulkExtensions;



namespace ApiCSV.CsvServicesAndDb.Services
{
    public class CsvDatabaseService : ICsvDatabaseService
    {
        private readonly ApplicationDbContext dbContext;

        public CsvDatabaseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task ImportCsvDataAsync(List<CsvDataDto> csvDataDtoList)
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await dbContext.BulkInsertAsync(csvDataDtoList);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
