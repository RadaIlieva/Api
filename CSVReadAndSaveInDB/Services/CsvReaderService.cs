using ApiCSV.DB;
using ApiCSV.DB.DTO;
using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;
using CSVReadAndSaveInDB.DB;
using CsvHelper.Configuration.Attributes;
using CSVReadAndSaveInDB.Services.Interface;

namespace CSVReadAndSaveInDB.Services
{
    public class CsvReaderService:ICsvReaderService
    {
        private readonly ApplicationDbContext dbContext;

        public CsvReaderService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<CsvDataDto> ReadCsvFilesFromDirectory(string directoryPath)
        {
            string[] csvFiles = Directory.GetFiles(directoryPath, "*.csv");
            List<CsvDataDto> allRecords = new List<CsvDataDto>();

            foreach (var failPath in csvFiles) 
            {
                using var reader = new StreamReader(failPath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);


                var records = csv.GetRecords<CsvDataDto>();
                allRecords.AddRange(records);


            }

            return allRecords;
        }
    }
}
