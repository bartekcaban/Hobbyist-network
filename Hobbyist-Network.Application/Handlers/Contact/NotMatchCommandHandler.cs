using Hobbyist_Network.Application.Commands.Contact;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Linq;

namespace Hobbyist_Network.Application.Handlers.Contact
{
    public class NotMatchCommandHandler : RequestHandler<NotMatchCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public NotMatchCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(NotMatchCommand request)
        {
            var contact = new Domain.Entities.Contact(Guid.NewGuid(), request.UserId, request.MatchedUserId, false);
            _dbContext.Contacts.Add(contact);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not add new contact");
            }
        }
    }
}
