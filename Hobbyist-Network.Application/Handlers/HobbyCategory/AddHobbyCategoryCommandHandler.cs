using Hobbyist_Network.Application.Commands.HobbyCategory;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System;

namespace Hobbyist_Network.Application.Handlers.User
{
    public class AddHobbyCategoryCommandHandler : RequestHandler<AddHobbyCategoryCommand>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public AddHobbyCategoryCommandHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Handle(AddHobbyCategoryCommand request)
        {
            var category = new Domain.Entities.HobbyCategory(Guid.NewGuid(), request.Name, request.Icon);
            _dbContext.HobbyCategories.Add(category);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not add category");
            }
        }
    }
}
