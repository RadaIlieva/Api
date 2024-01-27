using ApiCSV.CsvServicesAndDb.Services.Interface;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ApiCSV.CsvServicesAndDb.Services
{
    public class MoveCsvFileService : IMoveCsvFileService
    {
        public async Task MoveCsvFilesAsync(List<string> sourceFilePaths, string targetDirectory)
        {
            foreach (var sourceFilePath in sourceFilePaths)
            {
                string fileName = Path.GetFileName(sourceFilePath);
                string targetFilePath = Path.Combine(targetDirectory, fileName);

                await Task.Run(() => File.Move(sourceFilePath, targetFilePath));
            }
        }
    }
}
