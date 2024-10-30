using LojaFlex.Services.DTO;
using LojaFlex.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaFlex.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém os quantitativos para alimentar o dashboard.
        /// </summary>
        /// <returns></returns>
        [Route("GetDashboard")]
        [HttpGet]
        public async Task<ActionResult<DashboardDto>> GetDashboard()
        {
            var dashboard = await _service.GetDashboard();

            return Ok(dashboard);
        }
    }
}
