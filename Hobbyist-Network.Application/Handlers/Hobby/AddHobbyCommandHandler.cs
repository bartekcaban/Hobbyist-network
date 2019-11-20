using Hobbyist_Network.Application.Commands.Hobby;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;

namespace Hobbyist_Network.Application.Handlers.Hobby
{
    public class AddHobbyCommandHandler : RequestHandler<AddHobbyCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public AddHobbyCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(AddHobbyCommand request)
        {
            var hobby = new Domain.Entities.Hobby(Guid.NewGuid(), request.Description, request.CategoryId, request.UserId, request.Level);
            _dbContext.Hobbies.Add(hobby);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not add hobby");
            }
        }
    }
}
