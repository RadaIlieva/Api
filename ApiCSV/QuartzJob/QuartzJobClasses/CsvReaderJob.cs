using Quartz;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ApiCSV.CsvServicesAndDb.Services.Interface;

namespace ApiCSV.QuartzJob.QuartzJobClasses
{
    public class CsvReaderJob : IJob
    {
        private readonly IServiceProvider serviceProvider;

        public CsvReaderJob(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task Execute(IJobExecutionContext jobExecutionContext) 
        { 
            //using (var scope = serviceProvider.CreateScope())
            //{
            //    var csvReaderService = scope.ServiceProvider.GetRequiredService<ICsvReaderService>();
            //    var csvData = csvReaderService.ReadCsvFilesFromDirectory("C:\\your\\directory\\path");
            //}

            return Task.CompletedTask;
        }
    }
}
