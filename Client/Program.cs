using Client.ApiConection;
using Client.DisplayConsole;
using Client.DTO;
using Client.NewFolder;
using Client.SwitchServices;
using Client.SwitchServices.Interfaces;

internal class Program
{
    public static async Task Main(string[] args)
    {

        var apiUrl = "http://localhost:5054/api";
        var apiAuthenticationUrl = "http://localhost:5222/api";

        var apiCsvConnection = new ApiCsvConnection(apiUrl);
        var crudHttpClient = new CrudHttpClient(new HttpClient(), apiUrl);
        var apiStatisticConnection = new ApiStatisticConnection(apiUrl);
        var displayInfoConsole = new DisplayOrganizationMethods(crudHttpClient);
        var displayStatisticsMethods = new DisplayStatisticsMethods();
        var apiAuthenticationConnection = new ApiAutenticationConection(apiAuthenticationUrl);

        string choice = string.Empty;
        bool loggedIn = false;

        //do
        //{
        //    if (!loggedIn)
        //    {
        //        Console.WriteLine("Welcome!");
        //        Console.WriteLine("1. Register");
        //        Console.WriteLine("2. Log in");
        //        Console.Write("Choose operation: ");
        //        string loginChoice = Console.ReadLine();

        //        switch (loginChoice)
        //        {
        //            case "1":
        //                Console.Write("Enter your username: ");
        //                string registerUsername = Console.ReadLine();

        //                Console.Write("Enter your password: ");
        //                string registerPassword = Console.ReadLine();

        //                var userDto = new UserDTO
        //                {
        //                    UserName = registerUsername,
        //                    Password = registerPassword
        //                };

        //                await apiAuthenticationConnection.RegisterAsync(userDto, "UserRole");

        //                Console.WriteLine("Log in:");
        //                Console.Write("Enter your username: ");
        //                string loginUsername = Console.ReadLine();

        //                Console.Write("Enter your password: ");
        //                string loginPassword = Console.ReadLine();

        //                var loginDto = new UserDTO
        //                {
        //                    UserName = loginUsername,
        //                    Password = loginPassword
        //                };

        //                var token = await apiAuthenticationConnection.LoginAsync(loginDto);
        //                if (!string.IsNullOrEmpty(token))
        //                {
        //                    loggedIn = true;
        //                    Console.WriteLine();
        //                }
        //                break;

        //            case "2":
        //                Console.Write("Enter your username: ");
        //                 loginUsername = Console.ReadLine();

        //                Console.Write("Enter your password: ");
        //                 loginPassword = Console.ReadLine();

        //                 loginDto = new UserDTO
        //                {
        //                    UserName = loginUsername,
        //                    Password = loginPassword
        //                };

        //                 token = await apiAuthenticationConnection.LoginAsync(loginDto);
        //                if (!string.IsNullOrEmpty(token))
        //                {
        //                    loggedIn = true;
        //                    Console.WriteLine();
        //                }
        //                break;

        //            default:
        //                Console.WriteLine("Invalid choice");
        //                break;
        //        }
        //    }
        //    else
        //    {
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
                        IOrganizationConsoleService organizationService = new OrganizationConsoleService(crud, apiUrl,      displayInfoConsole, apiStatisticConnection, displayStatisticsMethods, apiCsvConnection, new AddOrganization());
                        await organizationService.HandleOperation(choice);
                    }

                } while (choice != "0");
        //    }
        //} while (choice != "0");

        Console.ReadLine();
    }
}
