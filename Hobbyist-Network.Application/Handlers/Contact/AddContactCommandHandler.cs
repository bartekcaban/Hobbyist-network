using Hobbyist_Network.Application.Commands.Contact;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;

namespace Hobbyist_Network.Application.Handlers.Contact
{
    public class AddContactCommandHandler : RequestHandler<AddContactCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public AddContactCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(AddContactCommand request)
        {
            var contact = new Domain.Entities.Contact(Guid.NewGuid(), request.UserId, request.MatchedUserId);
            _dbContext.Contacts.Add(contact);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not add new contact");
            }
        }
    }
}
