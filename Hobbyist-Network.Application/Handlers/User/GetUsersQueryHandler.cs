using AutoMapper;
using Hobbyist_Network.Application.DTOs.User;
using Hobbyist_Network.Application.Queries.User;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var users = _dbContext.Users;

            return users == null ? null : Mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
