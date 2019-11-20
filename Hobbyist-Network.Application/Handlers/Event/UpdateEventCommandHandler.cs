using Hobbyist_Network.Application.Commands.Event;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Linq;

namespace Hobbyist_Network.Application.Handlers.Event
{
    public class UpdateEventCommandHandler : RequestHandler<UpdateEventCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public UpdateEventCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(UpdateEventCommand request)
        {
            var _event = _dbContext.Events
                .FirstOrDefault(h => h.Id == request.Id);

            _event.Update(request.Name, request.Description, request.Localization, request.StartDate, request.EndDate, request.CategoryId);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not update event");
            }
        }
    }
}
