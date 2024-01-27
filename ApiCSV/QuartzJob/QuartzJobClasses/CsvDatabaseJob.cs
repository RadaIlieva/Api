using ApiCSV.CsvServicesAndDb.Services.Interface;
using Quartz;

namespace ApiCSV.QuartzJob.QuartzJobClasses
{
    public class CsvDatabaseJob : IJob
    {
        private readonly IServiceProvider serviceProvider;

        public CsvDatabaseJob(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task Execute(IJobExecutionContext jobExecutionContext)
        {
            //using (var scope = serviceProvider.CreateScope())
            //{
            //    var csvReaderService = scope.ServiceProvider.GetRequiredService<ICsvReaderService>();
            //    var csvDatabaseService = scope.ServiceProvider.GetRequiredService<ICsvDatabaseService>();

            //    var csvData = csvReaderService.ReadCsvFilesFromDirectory("C:\\Users\\radai\\Documents\\Projects\\API\\ApiCSV\\Data");
            //    csvDatabaseService.ImportCsvData(csvData);
            //}
            return Task.CompletedTask;
        }

    }
}
