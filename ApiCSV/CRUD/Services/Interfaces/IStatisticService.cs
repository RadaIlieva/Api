using ApiCSV.CRUD.DTOStatistics;
using ApiCSV.CsvServicesAndDb.DB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCSV.CRUD.Services.Interfaces
{
    public interface IStatisticService
    {
        public Task<IEnumerable<CsvDataDto>> GetOrganizationsWithMostEmployees(int count);

        public Task<IEnumerable<CountryStatisticsDto>> GetOrganizationsCountByCountry();
    }
}
