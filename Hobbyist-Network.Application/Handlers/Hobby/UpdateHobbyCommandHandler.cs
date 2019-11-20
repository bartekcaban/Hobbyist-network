using Hobbyist_Network.Application.Commands.Hobby;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;
using System.Linq;

namespace Hobbyist_Network.Application.Handlers.Hobby
{
    public class UpdateHobbyCommandHandler : RequestHandler<UpdateHobbyCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public UpdateHobbyCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(UpdateHobbyCommand request)
        {
            var hobby = _dbContext.Hobbies
                .FirstOrDefault(h => h.Id == request.Id);

            hobby.Update(request.Description, request.CategoryId, request.Level);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not update hobby");
            }
        }
    }
}
