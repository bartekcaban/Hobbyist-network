using Hobbyist_Network.Application.Commands.User;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Linq;

namespace Hobbyist_Network.Application.Handlers.User
{
    public class UpdateUserCommandHandler : RequestHandler<UpdateUserCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public UpdateUserCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(UpdateUserCommand request)
        {
            var user = _dbContext.Users
                .FirstOrDefault(e => e.Id == request.Id);

            user.Update(request.FirstName, request.LastName, request.Gender, request.City, request.PhoneNumber, request.Description, request.DateOfBirth);
        }
    }
}
