using ApiCSV.CsvServicesAndDb.DB.DTO;
using ApiCSV.CRUD.DTOStatistics;
using ApiCSV.CRUD.Services;
using ApiCSV.CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }

        [HttpGet("organizationsWithMostEmployees")]
        public async Task<ActionResult<IEnumerable<CsvDataDto>>> GetOrganizationsWithMostEmployees(int count)
        {
            var organizations = await statisticService.GetOrganizationsWithMostEmployees(count);

            if (organizations == null)
            {
                return NotFound();
            }

            return Ok(organizations);
        }

        [HttpGet("organizations-count-by-country")]
        public async Task<ActionResult<IEnumerable<CountryStatisticsDto>>> GetOrganizationsCountByCountry()
        {
            var statistics = await statisticService.GetOrganizationsCountByCountry();
            return Ok(statistics);
        }
    }
}
