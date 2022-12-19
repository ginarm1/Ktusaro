using AutoMapper;
using Ktusaro.Core.Models;
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

        [HttpPost("sponsorships")]
        public async Task<IActionResult> CreateSponsorShip(CreateSponsorshipRequest request)
        {
            var sponsorship = _mapper.Map<Sponsorship>(request);

            var insertedSponsorship = await _sponsorshipService.Create(sponsorship);
            var insertedSponsorResponse = _mapper.Map<SponsorshipResponse>(insertedSponsorship);

            return CreatedAtAction(nameof(GetSponsorshipById), new { id = insertedSponsorResponse.Id }, insertedSponsorResponse);
        }

        [HttpGet("sponsorships")]
        public async Task<IActionResult> GetAllSponsorships([FromQuery] SponsorshipFilterParameters parameters)
        {
            var sponsorships = await _sponsorshipService.GetAll(parameters.SponsorId,parameters.EventId);
            return Ok(_mapper.Map<List<SponsorshipResponse>>(sponsorships));
        }

        [HttpGet("sponsorships/{id}")]
        public async Task<IActionResult> GetSponsorshipById(int id)
        {
            var sponsorship = await _sponsorshipService.GetById(id);

            return Ok(sponsorship);
        }
    }
}
