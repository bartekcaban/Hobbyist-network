using Hobbyist_Network.Application.Commands.Hobby;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Linq;

namespace Hobbyist_Network.Application.Handlers.User
{
    public class DeleteHobbyCommandHandler : RequestHandler<DeleteHobbyCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public DeleteHobbyCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(DeleteHobbyCommand request)
        {
            var hobby = _dbContext.Hobbies
                .FirstOrDefault(h => h.Id == request.Id);

            _dbContext.Remove(hobby);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not delete hobby");
            }
        }
    }
}
