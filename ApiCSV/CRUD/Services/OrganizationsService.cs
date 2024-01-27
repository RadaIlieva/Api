using ApiCSV.CsvServicesAndDb.DB;
using ApiCSV.CsvServicesAndDb.DB.DTO;
using ApiCSV.CRUD.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiCSV.CRUD.Services
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


        public async Task<CsvDataDto> UpdateOrganization(string organizationId, CsvDataDto csvDataDto)
        {
            var organization = await context.CsvData.FindAsync(organizationId);

            if (organization == null)
            {
                return null;
            }

            
            if (organization.Name != csvDataDto.Name)
            {
                organization.Name = csvDataDto.Name;
            }

            if (organization.Website != csvDataDto.Website)
            {
                organization.Website = csvDataDto.Website;
            }

            if (organization.Country != csvDataDto.Country)
            {
                organization.Country = csvDataDto.Country;
            }

            if (organization.NumberOfEmployees != csvDataDto.NumberOfEmployees)
            {
                organization.NumberOfEmployees = csvDataDto.NumberOfEmployees;
            }

            await context.SaveChangesAsync();

            return new CsvDataDto
            {
                OrganizationId = organization.OrganizationId,
                Name = organization.Name,
                Website = organization.Website,
                Country = organization.Country,
                NumberOfEmployees = organization.NumberOfEmployees
            };
        }




        public async Task DeleteOrganization(string оrganizationId)
        {
            var organization = await context.CsvData.FindAsync(оrganizationId);

            context.CsvData.Remove(organization);
            await context.SaveChangesAsync();
        }
    }
}
