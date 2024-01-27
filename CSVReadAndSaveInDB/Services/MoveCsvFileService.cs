using CSVReadAndSaveInDB.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReadAndSaveInDB.Services
{
    public class MoveCsvFileService:IMoveCsvFileService
    {
        public void MoveCsvFiles(List<string> sourceFilePaths, string targetDirectory)
        {
            foreach (var sourceFilePath in sourceFilePaths)
            {
                string fileName = Path.GetFileName(sourceFilePath);
                string targetFilePath = Path.Combine(targetDirectory, fileName);

                File.Move(sourceFilePath, targetFilePath);
            }
        }
    }
}
