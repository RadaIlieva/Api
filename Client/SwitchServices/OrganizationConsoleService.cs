using ApiCSV.CsvServicesAndDb.DB.DTO;
using Client.ApiConection;
using Client.ApiConection.Interfaces;
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
        private readonly DisplayOrganizationMethods displayInfoConsole;
        private readonly IApiStatisticConnection statisticsConnection;
        private readonly DisplayStatisticsMethods displayStatisticsMethods;
        private readonly IApiCsvConnection apiCsvConnection1;
        private readonly AddOrganization addOrganization;

        private static readonly HttpClient httpClient = new HttpClient();

        public OrganizationConsoleService(CrudOperations crud, string apiUrl, DisplayOrganizationMethods displayInfoConsole, IApiStatisticConnection statisticsConnection, DisplayStatisticsMethods displayStatisticsMethods, IApiCsvConnection apiCsvConnection, AddOrganization addOrganization)
        {
            this.crud = crud;
            this.apiUrl = apiUrl;
            this.displayInfoConsole = displayInfoConsole;
            this.statisticsConnection = statisticsConnection;
            this.displayStatisticsMethods = displayStatisticsMethods;
            this.apiCsvConnection1 = apiCsvConnection;
            this.addOrganization = addOrganization;
        }

        public async Task HandleOperation(string choice)
        {
            CrudHttpClient apiOrganizationService = null;

            switch (choice)
            {
                case "1":
                    var apiCsvConnection = new ApiCsvConnection(apiUrl);
                    await apiCsvConnection.TestCsvController();
                    break;

                case "2":
                    var newOrganization = await addOrganization.CreateNewOrganization();
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
                    var updateOrganization = await addOrganization.CreateNewOrganization();

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
                case "8":
                    await apiCsvConnection1.TestCsvController();
                    break;

                case "0":
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

    }
}
