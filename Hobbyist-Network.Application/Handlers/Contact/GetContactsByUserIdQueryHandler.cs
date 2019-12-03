using AutoMapper;
using Hobbyist_Network.Application.DTOs.Contact;
using Hobbyist_Network.Application.Queries.Contact;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hobbyist_Network.Application.Handlers.Contact
{
    public class GetContactsByUserIdQueryHandler : RequestHandler<GetContactsByUserIdQuery, IEnumerable<ContactDto>>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public GetContactsByUserIdQueryHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override IEnumerable<ContactDto> Handle(GetContactsByUserIdQuery request)
        {
            var contacts = _dbContext.Contacts
                .Where(c => c.UserId == request.UserId || c.MatchedUserId == request.UserId);

            return contacts == null ? null : Mapper.Map<IEnumerable<ContactDto>>(contacts); ;
        }
    }
}
