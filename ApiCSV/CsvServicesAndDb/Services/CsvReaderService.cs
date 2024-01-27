using CsvHelper;
using System.Globalization;
using ApiCSV.CsvServicesAndDb.DB.DTO;
using ApiCSV.CsvServicesAndDb.DB;
using ApiCSV.CsvServicesAndDb.Services.Interface;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ApiCSV.CsvServicesAndDb.Services
{
    public class CsvReaderService : ICsvReaderService
    {
        private readonly ApplicationDbContext dbContext;

        public CsvReaderService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<CsvDataDto>> ReadCsvFilesFromDirectoryAsync(string directoryPath)
        {
            string[] csvFiles = Directory.GetFiles(directoryPath, "*.csv");

            var allRecords = new List<CsvDataDto>();

            foreach (var csvFile in csvFiles)
            {
                using var reader = new StreamReader(csvFile);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = await Task.Run(() => csv.GetRecords<CsvDataDto>().ToList());
                allRecords.AddRange(records);
            }

            return allRecords;
        }
    }
}
