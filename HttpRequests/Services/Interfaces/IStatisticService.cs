using ApiCSV.DB.DTO;
using HttpRequests.DTOStatistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequests.Services.Interfaces
{
    public interface IStatisticService
    {
        public Task<IEnumerable<CsvDataDto>> GetOrganizationsWithMostEmployees(int count);

        public Task<IEnumerable<CountryStatisticsDto>> GetOrganizationsCountByCountry();
    }
}
