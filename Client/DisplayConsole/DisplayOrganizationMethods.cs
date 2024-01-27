using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ApiConection;

namespace Client.NewFolder
{
    public class DisplayOrganizationMethods
    {
        private readonly CrudHttpClient crudHttpClient;

        public DisplayOrganizationMethods(CrudHttpClient crudHttpClient)
        {
            this.crudHttpClient = crudHttpClient;
        }

        public async Task DisplayOrganizationInfoAsync(string organizationId)
        {
            try
            {
                var organization = await crudHttpClient.GetOrganizationByIdAsync(organizationId);

                if (organization != null)
                {
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine($"Organization Name: {organization.Name}");
                    Console.WriteLine($"Country: {organization.Country}");
                    Console.WriteLine($"Industry: {organization.Industry}");
                    Console.WriteLine("-------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine($"Organization with ID {organizationId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while displaying organization info: {ex.Message}");
            }
        }

        public async Task DisplayDeleteOrganizationResultAsync(string organizationId, bool isDeleted)
        {
            if (isDeleted)
            {
                Console.WriteLine($"Organization with ID {organizationId} successfully deleted.");
            }
            else
            {
                Console.WriteLine($"Organization with ID {organizationId} not found or could not be deleted.");
            }
        }
    }
}

