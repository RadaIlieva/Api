using ApiCSV.CRUD.DTOStatistics;
using ApiCSV.CsvServicesAndDb.DB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ApiConection.Interfaces
{
    public interface IApiStatisticConnection
    {
        Task<IEnumerable<CsvDataDto>> GetOrganizationsWithMostEmployeesAsync(int count);

        Task<IEnumerable<CountryStatisticsDto>> GetOrganizationsCountByCountryAsync();
    }
}
