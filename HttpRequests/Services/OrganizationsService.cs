using ApiCSV.DB;
using ApiCSV.DB.DTO;
using CSVReadAndSaveInDB.DB;
using HttpRequests.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HttpRequests.Services
{
    public class OrganizationsService : IOrganizationService
    {
        private readonly ApplicationDbContext context;

        public OrganizationsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CsvDataDto>> GetOrganizations()
        {
            return await context.CsvData
                .Select(org => new CsvDataDto
                {
                    OrganizationId = org.OrganizationId,
                    Name = org.Name,
                    Website = org.Website,
                    Country = org.Country,
                    Description = org.Description,
                    Founded = org.Founded,
                    Industry = org.Industry,
                    NumberOfEmployees = org.NumberOfEmployees
                })
                .ToListAsync();
        }

        public async Task<CsvDataDto> GetOrganizationById(string organizationId)
        {
            var organization = await context.CsvData
                .Where(org => org.OrganizationId == organizationId)
                .Select(org => new CsvDataDto
                {
                    OrganizationId = org.OrganizationId,
                    Name = org.Name,
                    Website = org.Website,
                    Country = org.Country,
                    Description = org.Description,
                    Founded = org.Founded,
                    Industry = org.Industry,
                    NumberOfEmployees = org.NumberOfEmployees
                })
                .FirstOrDefaultAsync();

            return organization;
        }


        public async Task<string> AddOrganization(CsvDataDto csvDataDto)
        {
            
            var organization = new CsvDataDto
            {
                Index = csvDataDto.Index,
                OrganizationId = csvDataDto.OrganizationId,
                Name = csvDataDto.Name,
                Website = csvDataDto.Website,
                Country = csvDataDto.Country,
                Description = csvDataDto.Description,
                Founded = csvDataDto.Founded,
                Industry = csvDataDto.Industry,
                NumberOfEmployees = csvDataDto.NumberOfEmployees
            };


            context.CsvData.Add(organization);
            await context.SaveChangesAsync();

            return organization.OrganizationId;
        }


        public async Task UpdateOrganization(string organizationId, CsvDataDto csvDataDto)
        {
            var organization = await context.CsvData.FindAsync(organizationId);

            if (organization == null)
            {
                // Handle the case where the organization is not found
                return;
            }

            // Update the properties of the existing organization
            organization.Name = csvDataDto.Name;
            organization.Website = csvDataDto.Website;
            organization.Country = csvDataDto.Country;
            organization.Description = csvDataDto.Description;
            organization.Founded = csvDataDto.Founded;
            organization.Industry = csvDataDto.Industry;
            organization.NumberOfEmployees = csvDataDto.NumberOfEmployees;

            await context.SaveChangesAsync();
        }


        public async Task DeleteOrganization(string оrganizationId)
        {
            var organization = await context.CsvData.FindAsync(оrganizationId);

            context.CsvData.Remove(organization);
            await context.SaveChangesAsync();
        }
    }
}
