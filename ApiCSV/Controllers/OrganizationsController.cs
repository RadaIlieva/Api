using ApiCSV.CsvServicesAndDb.DB.DTO;
using ApiCSV.CRUD.Services;
using ApiCSV.CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ApiCSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService organizationsService;

        public OrganizationsController(IOrganizationService organizationsService)
        {
            this.organizationsService = organizationsService;
        }


        [HttpGet("{organizationId}")]
        [Authorize(Roles = "Admin, User")]
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
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<string>> AddOrganization(CsvDataDto csvDataDto)
        {
            var newOrganizationId = await organizationsService.AddOrganization(csvDataDto);

            return CreatedAtAction(nameof(GetOrganizationById), new { organizationId = newOrganizationId }, csvDataDto);
        }

        [HttpPut("{organizationId}")]
        [Authorize(Roles = "Admin, User")]
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteOrganization(string organizationId)
        {
            await organizationsService.DeleteOrganization(organizationId);
            return NoContent();
        }
    }
}
