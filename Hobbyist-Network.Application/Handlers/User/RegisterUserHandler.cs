using Hobbyist_Network.Application.Commands.User;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Handlers.User
{
    public class RegisterUserHandler : RequestHandler<RegisterUserCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public RegisterUserHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(RegisterUserCommand request)
        {
            var user = new Domain.Entities.User(Guid.NewGuid(), request.FirstName, request.LastName, request.Password, request.Email);
            _dbContext.Users.Add(user);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not register new user");
            }
        }
    }
}
