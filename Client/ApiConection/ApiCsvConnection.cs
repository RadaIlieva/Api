using Client.ApiConection.Interfaces;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.ApiConection
{
    public class ApiCsvConnection : IApiCsvConnection
    {
        private readonly string apiUrl;
        private long elapsedTime;

        public ApiCsvConnection(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }

        public long ElapsedTime => elapsedTime;

        public async Task TestCsvController()
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

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

                stopwatch.Stop();
                elapsedTime = stopwatch.ElapsedMilliseconds;

                Console.WriteLine($"Elapsed Time: {elapsedTime} milliseconds");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CsvController Test Exception: {ex.Message}");
            }
        }
    }
}
