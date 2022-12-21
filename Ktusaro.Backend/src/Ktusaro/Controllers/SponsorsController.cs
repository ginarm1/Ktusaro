using AutoMapper;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Core.Models;
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

        [HttpPost("sponsors")]
        public async Task<IActionResult> CreateSponsor(CreateSponsorRequest request)
        {
            var sponsor = _mapper.Map<Sponsor>(request);

            var insertedSponsor = await _sponsorService.Create(sponsor);
            var insertedSponsorResponse = _mapper.Map<SponsorResponse>(insertedSponsor);

            return CreatedAtAction(nameof(GetSponsorsById), new { id = insertedSponsorResponse.Id }, insertedSponsorResponse);
        }
        
        /// <summary>
        /// Get sponsors
        /// </summary>
        /// <returns></returns>
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

        [HttpPut("sponsors/{id}")]
        public async Task<IActionResult> Update(int id, CreateSponsorRequest request)
        {
            var sponsor = _mapper.Map<Sponsor>(request);

            var updatedSponsor = await _sponsorService.Update(id, sponsor);

            return Ok(_mapper.Map<SponsorResponse>(updatedSponsor));
        }

        [HttpDelete("sponsors/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedSponsorId = await _sponsorService.Delete(id);

            return Ok(deletedSponsorId);
        }
    }
}
