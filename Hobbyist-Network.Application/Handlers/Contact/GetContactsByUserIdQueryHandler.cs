using AutoMapper;
using Hobbyist_Network.Application.DTOs.Contact;
using Hobbyist_Network.Application.DTOs.Hobby;
using Hobbyist_Network.Application.Queries.Contact;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
                .Include(c => c.MatchedUser)
                .ThenInclude(m => m.Hobbies)
                .ThenInclude(m => m.Category)
                .Include(c => c.User)
                .ThenInclude(u => u.Hobbies)
                .ThenInclude(h => h.Category)
                .Where(c => (c.UserId == request.Id || c.MatchedUserId == request.Id) && c.Approved == true);

            var contactsList = new List<ContactDto>();

            foreach (var contact in contacts)
            {
                if (contact.UserId == request.Id)
                {
                    contactsList.Add(new ContactDto(
                        contact.Id,
                        contact.MatchedUserId,
                        contact.MatchedUser.Email,
                        contact.MatchedUser.FirstName,
                        contact.MatchedUser.LastName,
                        contact.MatchedUser.PhoneNumber,
                        contact.MatchedUser.DateOfBirth.Value,
                        contact.MatchedUser.Gender.Value,
                        contact.MatchedUser.City,
                        contact.MatchedUser.Description,
                        contact.MatchedUser.Instagram,
                        contact.MatchedUser.Facebook,
                        Mapper.Map<IEnumerable<HobbyDto>>(contact.MatchedUser.Hobbies),
                        contact.Date
                        ));
                }
                else
                {
                    contactsList.Add(new ContactDto(
                        contact.Id,
                        contact.UserId,
                        contact.User.Email,
                        contact.User.FirstName,
                        contact.User.LastName,
                        contact.User.PhoneNumber,
                        contact.User.DateOfBirth.Value,
                        contact.User.Gender.Value,
                        contact.User.City,
                        contact.User.Description,
                        contact.User.Instagram,
                        contact.User.Facebook,
                        Mapper.Map<IEnumerable<HobbyDto>>(contact.User.Hobbies),
                        contact.Date
                        ));
                }
            }

            return contacts == null ? null : contactsList;
        }
    }
}
