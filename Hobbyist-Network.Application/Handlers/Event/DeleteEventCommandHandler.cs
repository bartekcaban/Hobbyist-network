using Hobbyist_Network.Application.Commands.Event;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Linq;

namespace Hobbyist_Network.Application.Handlers.Event
{
    public class DeleteEventCommandHandler : RequestHandler<DeleteEventCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public DeleteEventCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(DeleteEventCommand request)
        {
            var _event = _dbContext.Events
                .FirstOrDefault(h => h.Id == request.Id);

            _dbContext.Remove(_event);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not delete event");
            }
        }
    }
}
