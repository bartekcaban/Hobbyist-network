using Hobbyist_Network.Application.Commands.Event;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;

namespace Hobbyist_Network.Application.Handlers.Event
{
    public class AddEventCommandHandler : RequestHandler<AddEventCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public AddEventCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(AddEventCommand request)
        {
            var _event = new Domain.Entities.Event(Guid.NewGuid(), request.Name, request.Description, request.Localization, request.StartDate, request.EndDate, request.OrganiserId, request.CategoryId);
            _dbContext.Events.Add(_event);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not add event");
            }
        }
    }
}
