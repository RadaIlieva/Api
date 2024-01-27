using ApiCSV.DB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReadAndSaveInDB.Services.Interface
{
    public interface ICsvDatabaseService
    {
        void ImportCsvData(List<CsvDataDto> csvDataDtoList);
    }
}
