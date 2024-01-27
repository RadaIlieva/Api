using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReadAndSaveInDB.Services.Interface
{
    public interface IMoveCsvFileService
    {
        public void MoveCsvFiles(List<string> sourceFilePaths, string targetDirectory);
    }
}
