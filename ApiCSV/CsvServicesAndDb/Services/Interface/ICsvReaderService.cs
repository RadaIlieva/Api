using ApiCSV.CsvServicesAndDb.DB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCSV.CsvServicesAndDb.Services.Interface
{
    public interface ICsvReaderService
    {
        public Task<List<CsvDataDto>> ReadCsvFilesFromDirectoryAsync(string directoryPath);
    }
}
