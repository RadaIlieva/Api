using ApiCSV.DB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequests.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<IEnumerable<CsvDataDto>> GetOrganizations();
        Task<CsvDataDto> GetOrganizationById(string organizationId);
        Task<string> AddOrganization(CsvDataDto organizationDto);
        Task UpdateOrganization(string organizationId, CsvDataDto csvDataDto);
        Task DeleteOrganization(string organizationId);
    }
}
