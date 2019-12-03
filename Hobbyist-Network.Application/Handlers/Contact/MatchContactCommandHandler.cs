using Hobbyist_Network.Application.Commands.Contact;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Linq;

namespace Hobbyist_Network.Application.Handlers.Contact
{
    public class MatchContactCommandHandler : RequestHandler<MatchContactCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public MatchContactCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(MatchContactCommand request)
        {
            var contact = _dbContext.Contacts
                .FirstOrDefault(c => c.Id == request.Id);

            contact.Match(request.Approved);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not match contact");
            }
        }
    }
}
