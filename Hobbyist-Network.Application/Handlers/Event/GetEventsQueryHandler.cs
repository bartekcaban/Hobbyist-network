using AutoMapper;
using Hobbyist_Network.Application.DTOs.Event;
using Hobbyist_Network.Application.Queries.Event;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hobbyist_Network.Application.Handlers.Event
{
    public class GetEventsQueryHandler : RequestHandler<GetEventsQuery, IEnumerable<EventDto>>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public GetEventsQueryHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override IEnumerable<EventDto> Handle(GetEventsQuery request)
        {
            var events = _dbContext.Events
                .Include(e => e.Category)
                .Include(e => e.Organiser)
                .Where(e => e.EndDate > DateTime.UtcNow)
                .OrderBy(e => e.StartDate);

            return Mapper.Map<IEnumerable<EventDto>>(events);
        }
    }
}
