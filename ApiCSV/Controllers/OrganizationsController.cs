using ApiCSV.CsvServicesAndDb.DB.DTO;
using ApiCSV.CRUD.Services;
using ApiCSV.CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService organizationsService;

        public OrganizationsController(IOrganizationService organizationsService)
        {
            this.organizationsService = organizationsService;
        }

        [HttpGet("get-organizations")]
        public async Task<ActionResult<IEnumerable<CsvDataDto>>> GetOrganizations()
        {
            var organizations = await organizationsService.GetOrganizations();
            return Ok(organizations);
        }

        [HttpGet("{organizationId}")]
        public async Task<ActionResult<CsvDataDto>> GetOrganizationById(string organizationId)
        {
            var organization = await organizationsService.GetOrganizationById(organizationId);

            if (organization == null)
            {
                return NotFound();
            }

            return Ok(organization);
        }

        [HttpPost("add-organization")]
        public async Task<ActionResult<string>> AddOrganization(CsvDataDto csvDataDto)
        {
            var newOrganizationId = await organizationsService.AddOrganization(csvDataDto);

            return CreatedAtAction(nameof(GetOrganizationById), new { organizationId = newOrganizationId }, csvDataDto);
        }

        [HttpPut("{organizationId}")]
        public async Task<ActionResult<CsvDataDto>> UpdateOrganization(string organizationId, CsvDataDto csvDataDto)
        {
            var updatedOrganization = await organizationsService.UpdateOrganization(organizationId, csvDataDto);

            if (updatedOrganization == null)
            {
                return NotFound();
            }

            return Ok(updatedOrganization); 
        }

        [HttpDelete("{organizationId}")]
        public async Task<ActionResult> DeleteOrganization(string organizationId)
        {
            await organizationsService.DeleteOrganization(organizationId);
            return NoContent();
        }
    }
}
