using AutoMapper;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Services.Services;
using Ktusaro.WebApp.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ktusaro.WebApp.Controllers
{
    [ApiController]
    [Route("api")]
    public class SponsorshipsController : ControllerBase
    {
        private readonly SponsorshipService _sponsorshipService;
        private readonly IMapper _mapper;

        public SponsorshipsController(SponsorshipService sponsorshipService, IMapper mapper)
        {
            _sponsorshipService = sponsorshipService;
            _mapper = mapper;
        }

        [HttpGet("sponsorships")]
        public async Task<IActionResult> GetAllSponsorships()
        {
            var sponsorships = await _sponsorshipService.GetAll();
            return Ok(_mapper.Map<List<SponsorshipResponse>>(sponsorships));
        }
    }
}
