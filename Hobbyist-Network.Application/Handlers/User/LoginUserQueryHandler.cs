using AutoMapper;
using Hobbyist_Network.Application.DTOs.User;
using Hobbyist_Network.Application.Queries.User;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hobbyist_Network.Application.Handlers.User
{
    public class LoginUserQueryHandler : RequestHandler<LoginUserQuery, UserDto>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public LoginUserQueryHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override UserDto Handle(LoginUserQuery request)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == request.Email &&
                                                   u.Password == request.Password);

            return user == null ? null : Mapper.Map<UserDto>(user);
        }
    }
}
