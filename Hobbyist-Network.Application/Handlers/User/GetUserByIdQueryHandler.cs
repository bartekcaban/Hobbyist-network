using AutoMapper;
using Hobbyist_Network.Application.DTOs.User;
using Hobbyist_Network.Application.Queries.User;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hobbyist_Network.Application.Handlers.User
{
    public class GetUserByIdQueryHandler : RequestHandler<GetUserByIdQuery, UserDto>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public GetUserByIdQueryHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override UserDto Handle(GetUserByIdQuery request)
        {
            var user = _dbContext.Users.Include(u => u.Hobbies).ThenInclude(h => h.Category)
                .FirstOrDefault(u => u.Id == request.Id);

            return user == null ? null : Mapper.Map<UserDto>(user);
        }
    }
}
