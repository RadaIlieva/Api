using ApiCSV.CsvServicesAndDb.DB.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.ApiConection
{
    public class CrudHttpClient : CrudOperations
    {
        public CrudHttpClient(HttpClient httpClient, string apiUrl)
            : base(httpClient, apiUrl)
        {
        }


        public override async Task<CsvDataDto> GetOrganizationByIdAsync(string organizationId)
        {
            try
            {
                var organizationUrl = $"{apiUrl}/Organizations/{organizationId}";

                var response = await httpClient.GetAsync(organizationUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var organization = JsonConvert.DeserializeObject<CsvDataDto>(content);
                    return organization;
                }
                else
                {
                    Console.WriteLine($"Failed to get organization by ID. Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while getting organization by ID: {ex.Message}");
            }

            return null;
        }



        public async Task<string> AddOrganizationAsync(CsvDataDto csvDataDto)
        {
            try
            {
                var addOrganizationUrl = $"{apiUrl}/Organizations/add-organization";

                var jsonContent = JsonConvert.SerializeObject(csvDataDto);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(addOrganizationUrl, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var newOrganizationId = await response.Content.ReadAsStringAsync();
                    return newOrganizationId;
                }
                else
                {
                    Console.WriteLine($"Failed to add organization. Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while adding organization: {ex.Message}");
            }

            return null;
        }


        public async Task UpdateOrganizationAsync(string organizationId, CsvDataDto csvDataDto)
        {
            try
            {
                var updateOrganizationUrl = $"{apiUrl}/Organizations/{organizationId}";

                var jsonContent = JsonConvert.SerializeObject(csvDataDto);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(updateOrganizationUrl, stringContent);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to update organization. Error: {response.StatusCode}");
                }
                else
                {
                    Console.WriteLine($"Organization updated successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while updating organization: {ex.Message}");
            }
        }


        public async Task DeleteOrganizationAsync(string organizationId)
        {
            try
            {
                var deleteOrganizationUrl = $"{apiUrl}/Organizations/{organizationId}";

                var response = await httpClient.DeleteAsync(deleteOrganizationUrl);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to delete organization. Error: {response.StatusCode}");
                }
                else
                {
                    Console.WriteLine($"Organization deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while deleting organization: {ex.Message}");
            }
        }

    }
}
