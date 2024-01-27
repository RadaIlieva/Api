using ApiCSV.CsvServicesAndDb.DB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DisplayConsole
{
    public class AddOrganization
    {
        public async Task<CsvDataDto> CreateNewOrganization()
        {
            Console.Write("Enter Organization Id: ");
            string organizationId = Console.ReadLine();

            Console.Write("Enter Organization Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Organization Website: ");
            string website = Console.ReadLine();

            Console.Write("Enter Organization Country: ");
            string country = Console.ReadLine();

            Console.Write("Enter Organization Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Organization Founded: ");
            if (int.TryParse(Console.ReadLine(), out int founded))
            {
                Console.Write("Enter Organization Industry: ");
                string industry = Console.ReadLine();

                Console.Write("Enter Organization Number of Employees: ");
                if (int.TryParse(Console.ReadLine(), out int numberOfEmployees))
                {
                    return new CsvDataDto
                    {
                        OrganizationId = organizationId,
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
