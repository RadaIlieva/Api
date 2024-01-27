using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ApiConection
{
    public class ApiCsvConnection
    {
        private readonly string apiUrl;

        public ApiCsvConnection(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }

        public async Task TestCsvController()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var csvControllerUrl = $"{apiUrl}/Csv/Test";

                    var response = await httpClient.GetAsync(csvControllerUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("CsvController Test Successful!");
                    }
                    else
                    {
                        Console.WriteLine($"CsvController Test Failed. Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CsvController Test Exception: {ex.Message}");
            }
        }
    }
}
