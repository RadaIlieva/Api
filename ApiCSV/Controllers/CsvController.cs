using ApiCSV.CsvServicesAndDb.DB.DTO;
using ApiCSV.CsvServicesAndDb.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

[Route("api/[controller]")]
[ApiController]
public class CsvController : ControllerBase
{
    private readonly ICsvReaderService csvReaderService;
    private readonly ICsvDatabaseService csvDatabaseWriterService;
    private readonly IMoveCsvFileService moveCsvFileService;

    public CsvController(ICsvReaderService csvReaderService,
                         ICsvDatabaseService csvDatabaseWriterService,
                         IMoveCsvFileService moveCsvFileService)
    {
        this.csvReaderService = csvReaderService;
        this.csvDatabaseWriterService = csvDatabaseWriterService;
        this.moveCsvFileService = moveCsvFileService;
    }

    [HttpGet("Test")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CsvDataDto>>> Test()
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var directoryPath = Path.Combine("C:/Users/radai/Documents/Projects/API/ApiDataCsv/Data");
            var csvDataTask = csvReaderService.ReadCsvFilesFromDirectoryAsync(directoryPath);

            var sourceFilePaths = Directory.GetFiles(directoryPath, "*.csv").ToList();
            var targetDirectory = Path.Combine("C:/Users/radai/Documents/Projects/API/ApiDataCsv/ReadedData");

            await csvDatabaseWriterService.ImportCsvDataAsync(await csvDataTask);

            var moveCsvFilesTask = moveCsvFileService.MoveCsvFilesAsync(sourceFilePaths, targetDirectory);
            await Task.WhenAll(moveCsvFilesTask);

            foreach (var sourceFilePath in sourceFilePaths)
            {
                System.IO.File.Delete(sourceFilePath);
            }

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Time: {elapsedTime} ");

            return Ok(); 
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }

}
