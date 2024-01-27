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
        private readonly string apiAutenticationUrl;
        private readonly HttpClient httpClient;

        public ApiAutenticationConection(string apiAutenticationUrl)
        {
            this.apiAutenticationUrl = apiAutenticationUrl;
            this.httpClient = new HttpClient();
        }

        public async Task<string> RegisterAsync(UserDTO userDto, string role)
        {
            try
            {
                var registerUrl = $"{apiAutenticationUrl}/Authentication/register?role={role}";

                var jsonContent = JsonConvert.SerializeObject(userDto);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(registerUrl, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var registeredUser = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"User {userDto.UserName} registered successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to register user. Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while registering user: {ex.Message}");
            }

            return null;
        }

        public async Task<string> LoginAsync(UserDTO userDto)
        {
            try
            {
                var loginUrl = $"{apiAutenticationUrl}/Authentication/login";

                var jsonContent = JsonConvert.SerializeObject(userDto);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(loginUrl, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Logged in successfully. Token: {token}");

                    return token;
                }
                else
                {
                    Console.WriteLine($"Failed to login. Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while logging in: {ex.Message}");
            }

            return null;
        }

    }
}
