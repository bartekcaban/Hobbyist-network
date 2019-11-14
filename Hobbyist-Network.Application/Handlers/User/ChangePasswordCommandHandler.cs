using Hobbyist_Network.Application.Commands.User;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Linq;

namespace Hobbyist_Network.Application.Handlers.User
{
    public class ChangePasswordCommandHandler : RequestHandler<ChangePasswordCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public ChangePasswordCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(ChangePasswordCommand request)
        {
            var user = _dbContext.Users
                .FirstOrDefault(e => e.Id == request.Id);

            user.ChangePassword(request.Password);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not change password");
            }
        }
    }
}
