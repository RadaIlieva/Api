using System;
using System.Net.Http;
using System.Threading.Tasks;
using Autentication.Enums;
using Client.ApiConection;
using Client.Constants;
using Client.DisplayConsole;
using Client.DTO;
using Client.NewFolder;
using Client.SwitchServices;
using Client.SwitchServices.Interfaces;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var apiUrl = ApiConstants.BaseUrl;
        var apiAuthenticationUrl = ApiConstants.AuthenticationUrl;

        var apiCsvConnection = new ApiCsvConnection(apiUrl);
        var crudHttpClient = new CrudHttpClient(new HttpClient(), apiUrl);
        var apiStatisticConnection = new ApiStatisticConnection(apiUrl);
        var displayInfoConsole = new DisplayOrganizationMethods(crudHttpClient);
        var displayStatisticsMethods = new DisplayStatisticsMethods();
        var apiAuthenticationConnection = new ApiAutenticationConection(apiAuthenticationUrl);

        string choice;

        do
        {
            Console.WriteLine("Registration:");
            var registrationUser = GetUserInput();
            await apiAuthenticationConnection.RegisterAsync(registrationUser);

            Console.WriteLine("Login:");
            var loginUser = GetUserInput();
            var token = await apiAuthenticationConnection.LoginAsync(loginUser);

            if (token != null)
            {
                Console.WriteLine($"Login successful. Token: {token}");

                Console.WriteLine("*** Organization-related operations:");
                Console.WriteLine("2. Add Organization");
                Console.WriteLine("3. Get Organization by Id");
                Console.WriteLine("4. Update Organization");
                Console.WriteLine("5. Delete Organization");

                Console.WriteLine();
                Console.WriteLine("*** Statistic methods:");
                Console.WriteLine("6. Get Organizations With Most Employees");
                Console.WriteLine("7. Get Organizations Count By Country");
                Console.WriteLine("8. CSV ");
                Console.WriteLine("0. Exit");

                do
                {
                    Console.Write("Choose operation: ");
                    choice = Console.ReadLine();

                    using (var httpClient = new HttpClient())
                    {
                        CrudOperations crud = new CrudHttpClient(httpClient, apiUrl);
                        IOrganizationConsoleService organizationService = new OrganizationConsoleService(
                            crud,
                            apiUrl,
                            displayInfoConsole,
                            apiStatisticConnection,
                            displayStatisticsMethods,
                            apiCsvConnection,
                            new AddOrganization()
                        );
                        await organizationService.HandleOperation(choice);
                    }

                } while (choice != "0");
            }
            else
            {
                Console.WriteLine("Login failed. Exiting...");
                choice = "0";
            }

        } while (choice != "0");

        Console.ReadLine();
    }

    private static UserDTO GetUserInput()
    {
        Console.Write("Enter your username: ");
        var username = Console.ReadLine();

        Console.Write("Enter your password: ");
        var password = Console.ReadLine();

        Console.Write("Enter your role (User/Admin): ");
        var role = Console.ReadLine();

        return new UserDTO { UserName = username, Password = password, Role = (UserRole)Enum.Parse(typeof(UserRole), role) };
    }
}
