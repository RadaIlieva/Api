using ApiCSV.CsvServicesAndDb.Services.Interface;
using Quartz;

namespace ApiCSV.QuartzJob.QuartzJobClasses
{
    public class MoveCsvFileJob:IJob
    {
        private readonly IServiceProvider serviceProvider;

        public MoveCsvFileJob(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task Execute(IJobExecutionContext jobExecutionContext)
        {
            //using (var scope = serviceProvider.CreateScope())
            //{
            //    var moveCsvFileService = scope.ServiceProvider.GetRequiredService<IMoveCsvFileService>();

            //    var sourceFilePaths = Directory.GetFiles("C:\\Users\\radai\\Documents\\Projects\\API\\ApiCSV\\Data", "*.csv").ToList();
            //    var targetDirectory = "C:\\Users\\radai\\Documents\\Projects\\API\\ApiCSV\\ReadedData";

            //    moveCsvFileService.MoveCsvFiles(sourceFilePaths, targetDirectory);
            //}
            
            return Task.CompletedTask;
        }
    }
}
