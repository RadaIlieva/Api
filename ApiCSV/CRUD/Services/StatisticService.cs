using ApiCSV.CRUD.DTOStatistics;
using ApiCSV.CsvServicesAndDb.DB;
using ApiCSV.CsvServicesAndDb.DB.DTO;
using ApiCSV.CRUD.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCSV.CRUD.Services
{
    public class StatisticService: IStatisticService
    {
        private readonly ApplicationDbContext context;

        public StatisticService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CsvDataDto>> GetOrganizationsWithMostEmployees(int count)
        {
            return await context.CsvData
                .OrderByDescending(org => org.NumberOfEmployees)
                .Take(count)
                .Select(org => new CsvDataDto
                {
                    OrganizationId = org.OrganizationId,
                    Name = org.Name,
                    Website = org.Website,
                    Country = org.Country,
                    Description = org.Description,
                    Founded = org.Founded,
                    Industry = org.Industry,
                    NumberOfEmployees = org.NumberOfEmployees
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CountryStatisticsDto>> GetOrganizationsCountByCountry()
        {
            var statistics = await context.CsvData
                .GroupBy(org => org.Country)
                .Select(group => new CountryStatisticsDto
                {
                    Country = group.Key,
                    NumberOfOrganizations = group.Count()
                })
                .ToListAsync();

            return statistics;
        }
    }
}
