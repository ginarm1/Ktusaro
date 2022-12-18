﻿using Ktusaro.Core.Exceptions;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Core.Models;

namespace Ktusaro.Services.Services
{
    public class SponsorshipService : ISponsorshipService
    {
        private readonly ISponsorshipRepository _sponsorshipRepository;
        private readonly ISponsorRepository _sponsorRepository;
        private readonly IEventRepository _eventRepository;

        public SponsorshipService(ISponsorshipRepository sponsorshipRepository, ISponsorRepository sponsorRepository, IEventRepository eventRepository)
        {
            _sponsorshipRepository = sponsorshipRepository;
            _sponsorRepository = sponsorRepository;
            _eventRepository = eventRepository;
        }

        public async Task<List<Sponsorship>> GetAll()
        {
            var sponsorships = await _sponsorshipRepository.GetAll();

            if (sponsorships == null)
            {
                throw new SponsorshipNotFound();
            }

            return sponsorships;
        }

        public async Task<Sponsorship> GetById(int id)
        {
            var sponsorship = await _sponsorshipRepository.GetById(id);

            if (sponsorship == null)
            {
                throw new SponsorshipNotFound();
            }

            return sponsorship;
        }

        public async Task<Sponsorship> Create(Sponsorship sponsorship)
        {
            var sponsor = await _sponsorRepository.GetById(sponsorship.SponsorId);

            if (sponsor == null)
            {
                throw new SponsorNotFound();
            }

            var @event = await _eventRepository.GetById(sponsorship.EventId);
            
            if (@event == null)
            {
                throw new EventNotFound();
            }

            var insertedSponsorshipId = await _sponsorshipRepository.Create(sponsorship);
            var insertedSponsorship = await _sponsorshipRepository.GetById(insertedSponsorshipId);

            return insertedSponsorship;
        }

        public async Task<Sponsorship> Update(int id, Sponsorship sponsorship)
        {
            if (await _sponsorshipRepository.GetById(id) == null)
            {
                throw new SponsorshipNotFound();
            }

            var updatedSponsorshipId = await _sponsorshipRepository.Update(id, sponsorship);
            var updatedSponsorship = await _sponsorshipRepository.GetById(updatedSponsorshipId);

            return updatedSponsorship;
        }
    }
}
