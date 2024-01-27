using ApiCSV.CRUD.DTOStatistics;
using ApiCSV.CsvServicesAndDb.DB.DTO;
using System;
using System.Collections.Generic;

namespace Client.DisplayConsole
{
    public class DisplayStatisticsMethods
    {
        public void DisplayOrganizationsWithMostEmployees(IEnumerable<CsvDataDto> organizations)
        {
            Console.WriteLine();
            Console.WriteLine("***  Top 5 organizations with most employees:  ");
            foreach (var org in organizations)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------");
                //Console.WriteLine($"Organization ID: {org.OrganizationId}");
                Console.WriteLine($"Name: {org.Name}");
                //Console.WriteLine($"Website: {org.Website}");
                Console.WriteLine($"Country: {org.Country}");
                Console.WriteLine($"Description: {org.Description}");
                //Console.WriteLine($"Founded: {org.Founded}");
                Console.WriteLine($"Industry: {org.Industry}");
                Console.WriteLine($"Number of Employees: {org.NumberOfEmployees}");
                
                
            }
        }

        public void DisplayOrganizationsCountByCountry(IEnumerable<CountryStatisticsDto> statistics)
        {
            Console.WriteLine("***  The numbers of the organizations in every countrys:");
            foreach (var stat in statistics)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"Country: {stat.Country}");
                Console.WriteLine($"Number of Organizations: {stat.NumberOfOrganizations}");
                
            }
        }
    }
}
