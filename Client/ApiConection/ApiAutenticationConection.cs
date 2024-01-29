using Autentication.Models;
using Client.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.ApiConection
{
    public class ApiAutenticationConection
    {
        private readonly string apiUrl;

        public ApiAutenticationConection(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }

        public async Task RegisterAsync(UserDTO userDto)
        {
            using (var httpClient = new HttpClient())
            {
                var requestUrl = $"{apiUrl}/api/Autentication/register";
                var content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(requestUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Registration failed. Status code: {response.StatusCode}");
                }
                else
                {
                    Console.WriteLine("Registration successful.");
                }
            }
        }

        public async Task<string> LoginAsync(UserDTO userDto)
        {
            using (var httpClient = new HttpClient())
            {
                var requestUrl = $"{apiUrl}/api/Autentication/login";
                var content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Login successful. Token: {token}");
                    return token;
                }
                else
                {
                    Console.WriteLine($"Login failed. Status code: {response.StatusCode}");
                    return null;
                }
            }
        }
    }
}
