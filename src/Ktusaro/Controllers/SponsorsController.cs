using AutoMapper;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Services.Services;
using Ktusaro.WebApp.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ktusaro.WebApp.Controllers
{
    [ApiController]
    [Route("api")]
    public class SponsorsController : ControllerBase
    {
        private readonly SponsorService _sponsorService;
        private readonly IMapper _mapper;

        public SponsorsController(SponsorService sponsorService, IMapper mapper)
        {
            _sponsorService = sponsorService;
            _mapper = mapper;
        }

        [HttpGet("sponsors")]
        public async Task<IActionResult> GetAllSponsors()
        {
            var sponsors = await _sponsorService.GetAll();
            return Ok(_mapper.Map<List<SponsorResponse>>(sponsors));
        }

        [HttpGet("sponsors/{id}")]
        public async Task<IActionResult> GetSponsorsById(int id)
        {
            var sponsor = await _sponsorService.GetById(id);

            return Ok(sponsor);
        }
    }
}
