using Autentication.Enums;
using Autentication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.SwitchServices
{
    public class AuthApiClient
    {
        private const string ApiUrl = "http://localhost:5157";
        private readonly string RegisterUrl = $"{ApiUrl}/api/Authentication/register";
        private readonly string LoginUrl = $"{ApiUrl}/api/Authentication/login";
        private readonly HttpClient httpClient;

        public AuthApiClient()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<bool> RegisterAndLogin()
        {
            bool loggedIn = false;

            do
            {
                PrintMenu();
                string choice = Console.ReadLine();

                loggedIn = await HandleChoice(choice);
            } while (!loggedIn);

            return loggedIn;
        }

        private void PrintMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");
        }

        private async Task<bool> HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    return await RegisterAndLoginInternal("Registration");

                case "2":
                    return await RegisterAndLoginInternal("Login");

                case "0":
                    Console.WriteLine("Exiting the program.");
                    return true;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return false;
            }
        }

        private async Task<bool> RegisterAndLoginInternal(string action)
        {
            Console.WriteLine($"{action}:");

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Console.Write("Enter your role (User/Admin): ");
            string roleString = Console.ReadLine();

            if (Enum.TryParse<UserRole>(roleString, out UserRole role))
            {
                var userDto = new UserDto
                {
                    Username = username,
                    Password = password,
                    Role = role
                };

                var url = action == "Registration" ? RegisterUrl : LoginUrl;

                var content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"{action} successful.");
                    if (action == "Registration")
                    {
                        return await RegisterAndLoginInternal("Login");
                    }
                    else if (action == "Login")
                    {
                        var token = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Login successful. Token: {token}");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine($"{action} unsuccessful. Status code: {response.StatusCode}");
                }
            }
            else
            {
                Console.WriteLine("Invalid role input. Please enter 'User' or 'Admin'.");
            }

            return false;
        }

    }
}