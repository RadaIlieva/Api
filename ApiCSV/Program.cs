using Quartz;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ApiCSV.CsvServicesAndDb.DB;
using ApiCSV.CsvServicesAndDb.Services.Interface;
using ApiCSV.CsvServicesAndDb.Services;
using ApiCSV.CRUD.Services.Interfaces;
using ApiCSV.CRUD.Services;

namespace ApiCSV
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<ICsvReaderService, CsvReaderService>();
            builder.Services.AddScoped<ICsvDatabaseService, CsvDatabaseService>();
            builder.Services.AddScoped<IMoveCsvFileService, MoveCsvFileService>();

            builder.Services.AddScoped<IOrganizationService, OrganizationsService>();
            builder.Services.AddScoped<IStatisticService, StatisticService>();

            //builder.Services.AddQuartz(q =>
            //{
            //    q.UseMicrosoftDependencyInjectionScopedJobFactory();

               
            //    q.AddJob<CsvReaderJob>("CsvReaderJob")
            //        .AddTrigger(t => t
            //            .WithIdentity("CsvReaderJobTrigger")
            //            .StartNow()
            //            .WithSimpleSchedule(x => x
            //                .WithIntervalInHours(12)
            //                .RepeatForever()));

                
            //    q.AddJob<CsvDatabaseJob>("CsvDatabaseJob")
            //        .AddTrigger(t => t
            //            .WithIdentity("CsvDatabaseJobTrigger")
            //            .StartNow()
            //            .WithSimpleSchedule(x => x
            //                .WithIntervalInHours(12)
            //                .RepeatForever()));

                
            //    q.AddJob<MoveCsvFileJob>("MoveCsvFileJob")
            //        .AddTrigger(t => t
            //            .WithIdentity("MoveCsvFileJobTrigger")
            //            .StartNow()
            //            .WithSimpleSchedule(x => x
            //                .WithIntervalInHours(12)
            //                .RepeatForever()));
            //});

            //builder.Services.AddQuartzHostedService();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
