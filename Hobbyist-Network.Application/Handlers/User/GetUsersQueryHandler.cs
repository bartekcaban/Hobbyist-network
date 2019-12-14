using AutoMapper;
using Hobbyist_Network.Application.DTOs.User;
using Hobbyist_Network.Application.Queries.User;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hobbyist_Network.Application.Handlers.User
{
    public class GetUsersQueryHandler : RequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public GetUsersQueryHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override IEnumerable<UserDto> Handle(GetUsersQuery request)
        {
            var users = _dbContext.Users
                .Include(u => u.Hobbies)
                .ThenInclude(h => h.Category)
                .Where(u => u.Id != request.Id);

            var contacts = _dbContext.Contacts.Where(c => c.MatchedUserId == request.Id || c.UserId == request.Id);

            var currentUser = _dbContext.Users.Include(u => u.Hobbies).Where(u => u.Id == request.Id).SingleOrDefault();

            var dictionary = new List<GetUsersDto>();

            foreach(var user in users)
            {
                foreach(var contact in contacts)
                {
                    if(user.Id == contact.UserId || user.Id == contact.MatchedUserId)
                    {
                        users = users.Where(u => u.Id != user.Id);
                    }
                }
            }
            foreach(var user in users)
            {
                var points = 0;

                foreach(var hobby in user.Hobbies)
                {
                    foreach (var currentHobby in currentUser.Hobbies)
                    {
                        if (hobby.CategoryId == currentHobby.CategoryId)
                            points = points + 2;
                        if (hobby.Level == currentHobby.Level)
                            points = points + 1;
                    }
                }

                dictionary.Add(new GetUsersDto(points, user));
            }

            var sorted = dictionary.OrderByDescending(d => d.Key).ToList();

            return sorted == null ? null : Mapper.Map<IEnumerable<UserDto>>(sorted);
        }
    }
}
