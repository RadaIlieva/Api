using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCSV.CsvServicesAndDb.Services.Interface
{
    public interface IMoveCsvFileService
    {
        Task MoveCsvFilesAsync(List<string> sourceFilePaths, string targetDirectory);
    }
}
