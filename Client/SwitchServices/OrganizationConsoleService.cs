using ApiCSV.CsvServicesAndDb.DB.DTO;
using Client.ApiConection;
using Client.DisplayConsole;
using Client.NewFolder;
using Client.SwitchServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.SwitchServices
{
    public class OrganizationConsoleService : IOrganizationConsoleService
    {
        private readonly CrudOperations crud;
        private readonly string apiUrl;
        private readonly HttpClient httpClient;
        private readonly DisplayOrganizationMethods displayInfoConsole;
        private readonly ApiStatisticConnection statisticsConnection;
        private readonly DisplayStatisticsMethods displayStatisticsMethods;

        public OrganizationConsoleService(CrudOperations crud, string apiUrl, DisplayOrganizationMethods displayInfoConsole, ApiStatisticConnection statisticsConnection, DisplayStatisticsMethods displayStatisticsMethods)
        {
            this.crud = crud;
            this.apiUrl = apiUrl;
            this.httpClient = new HttpClient();
            this.displayInfoConsole = displayInfoConsole;
            this.statisticsConnection = statisticsConnection;
            this.displayStatisticsMethods = displayStatisticsMethods;
        }

        public async Task HandleOperation(string choice)
        {
            CrudHttpClient apiOrganizationService = null;  // Initialize the variable outside the switch

            switch (choice)
            {
                case "1":
                    var apiCsvConnection = new ApiCsvConnection(apiUrl);
                    await apiCsvConnection.TestCsvController();
                    break;

                case "2":
                    var newOrganization = await CreateNewOrganization();
                    if (newOrganization != null)
                    {
                        apiOrganizationService = new CrudHttpClient(httpClient, apiUrl);
                        var newOrganizationId = await apiOrganizationService.AddOrganizationAsync(newOrganization);
                        Console.WriteLine($"New organization added with ID: {newOrganizationId}");
                    }
                    break;

                case "3":
                    Console.Write("Enter Organization ID: ");
                    string organizationId = Console.ReadLine();
                    await displayInfoConsole.DisplayOrganizationInfoAsync(organizationId);
                    break;

                case "4":
                    Console.Write("Enter Organization ID: ");
                    string updateOrganizationId = Console.ReadLine();
                    var updateOrganization = await CreateNewOrganization();
                    if (updateOrganization != null)
                    {
                        apiOrganizationService = new CrudHttpClient(httpClient, apiUrl);
                        await apiOrganizationService.UpdateOrganizationAsync(updateOrganizationId, updateOrganization);
                    }
                    break;

                case "5":
                    Console.Write("Enter Organization ID to delete: ");
                    string deleteOrganizationId = Console.ReadLine();
                    apiOrganizationService = new CrudHttpClient(httpClient, apiUrl);
                    await apiOrganizationService.DeleteOrganizationAsync(deleteOrganizationId);
                    break;


                case "6":
                    var organizationsWithMostEmployees = await statisticsConnection.GetOrganizationsWithMostEmployeesAsync(5);
                    displayStatisticsMethods.DisplayOrganizationsWithMostEmployees(organizationsWithMostEmployees);
                    break;

                case "7":
                    var statistics = await statisticsConnection.GetOrganizationsCountByCountryAsync();
                    displayStatisticsMethods.DisplayOrganizationsCountByCountry(statistics);
                    break;

                case "0":
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        private async Task<CsvDataDto> CreateNewOrganization()
        {
            Console.Write("Enter Organization Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Organization Website: ");
            string website = Console.ReadLine();

            Console.Write("Enter Organization Country: ");
            string country = Console.ReadLine();

            Console.Write("Enter Organization Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Organization Founded : ");
            if (int.TryParse(Console.ReadLine(), out int founded))
            {
                Console.Write("Enter Organization Industry: ");
                string industry = Console.ReadLine();

                Console.Write("Enter Organization Number of Employees: ");
                if (int.TryParse(Console.ReadLine(), out int numberOfEmployees))
                {

                    return new CsvDataDto
                    {
                        Name = name,
                        Website = website,
                        Country = country,
                        Description = description,
                        Founded = founded,
                        Industry = industry,
                        NumberOfEmployees = numberOfEmployees
                    };
                }
                else
                {
                    Console.WriteLine("Invalid input for Number of Employees.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Founded date.");
            }

            return null; 
        }

    }
}
