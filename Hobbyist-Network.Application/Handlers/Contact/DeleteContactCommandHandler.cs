using Hobbyist_Network.Application.Commands.Contact;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Linq;

namespace Hobbyist_Network.Application.Handlers.Contact
{
    public class DeleteContactCommandHandler : RequestHandler<DeleteContactCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public DeleteContactCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(DeleteContactCommand request)
        {
            var contact = _dbContext.Contacts
                .FirstOrDefault(c => c.Id == request.Id);

            contact.Delete();

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not delete contact");
            }
        }
    }
}
