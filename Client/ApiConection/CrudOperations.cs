
using ApiCSV.CsvServicesAndDb.DB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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
        //public Task<string> AddOrganizationAsync(CsvDataDto csvDataDto);
        //public Task UpdateOrganizationAsync(string organizationId, CsvDataDto csvDataDto);
        //public Task DeleteOrganizationAsync(string organizationId);



    }
}
