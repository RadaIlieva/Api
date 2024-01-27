using ApiCSV.CsvServicesAndDb.DB.DTO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace Client.ApiConection
{
    public abstract class CrudOperations
    {
        protected readonly HttpClient httpClient;
        protected readonly string apiUrl;

        public CrudOperations(HttpClient httpClient, string apiUrl)
        {
            this.httpClient = httpClient;
            this.apiUrl = apiUrl;
        }

        public abstract Task<CsvDataDto> GetOrganizationByIdAsync(string organizationId);
        public abstract Task<string> AddOrganizationAsync(CsvDataDto csvDataDto);
        public abstract Task UpdateOrganizationAsync(string organizationId, CsvDataDto csvDataDto);
        public abstract Task DeleteOrganizationAsync(string organizationId);
    }
}
