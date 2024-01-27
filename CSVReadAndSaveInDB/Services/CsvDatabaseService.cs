using ApiCSV.DB;
using System.Collections.Generic;
using System.Linq;
using CSVReadAndSaveInDB.DB;
using ApiCSV.DB.DTO;
using CSVReadAndSaveInDB.Services.Interface;

namespace CSVReadAndSaveInDB.Services
{
    public class CsvDatabaseService : ICsvDatabaseService
    {
        private readonly ApplicationDbContext dbContext;

        public CsvDatabaseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void ImportCsvData(List<CsvDataDto> csvDataDtoList)
        {
            foreach (var csvDataDto in csvDataDtoList)
            {
                // Пример: Записване на данни в таблица "Organizations" в базата данни
                var organization = new CsvDataDto
                {
                    OrganizationId = csvDataDto.OrganizationId,
                    Name = csvDataDto.Name,
                    Website = csvDataDto.Website,
                    Country = csvDataDto.Country,
                    Description = csvDataDto.Description,
                    Founded = csvDataDto.Founded,
                    Industry = csvDataDto.Industry,
                    NumberOfEmployees = csvDataDto.NumberOfEmployees
                };

                dbContext.CsvData.Add(organization);
            }

            dbContext.SaveChanges();
        }
    }
}
