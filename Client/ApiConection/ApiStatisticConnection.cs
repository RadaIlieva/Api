using ApiCSV.CRUD.DTOStatistics;
using ApiCSV.CsvServicesAndDb.DB.DTO;
using Client.ApiConection.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ApiConection
{
    public class ApiStatisticConnection : IApiStatisticConnection
    {
        private readonly string apiUrl;

        public ApiStatisticConnection(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }

        public async Task<IEnumerable<CsvDataDto>> GetOrganizationsWithMostEmployeesAsync(int count)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var statisticControllerUrl = $"{apiUrl}/Statistic/organizationsWithMostEmployees?count={count}";

                    var response = await httpClient.GetAsync(statisticControllerUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var organizations = JsonConvert.DeserializeObject<IEnumerable<CsvDataDto>>(content);
                        return organizations;
                    }
                    else
                    {
                        Console.WriteLine($"GetOrganizationsWithMostEmployeesAsync Failed. Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetOrganizationsWithMostEmployeesAsync Exception: {ex.Message}");
            }

            return Enumerable.Empty<CsvDataDto>();
        }

        public async Task<IEnumerable<CountryStatisticsDto>> GetOrganizationsCountByCountryAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var statisticControllerUrl = $"{apiUrl}/Statistic/organizations-count-by-country";

                    var response = await httpClient.GetAsync(statisticControllerUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var statistics = JsonConvert.DeserializeObject<IEnumerable<CountryStatisticsDto>>(content);
                        return statistics;
                    }
                    else
                    {
                        Console.WriteLine($"GetOrganizationsCountByCountryAsync Failed. Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetOrganizationsCountByCountryAsync Exception: {ex.Message}");
            }

            return Enumerable.Empty<CountryStatisticsDto>();
        }
    }

}
