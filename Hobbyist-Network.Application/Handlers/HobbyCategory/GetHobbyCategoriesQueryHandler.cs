using AutoMapper;
using Hobbyist_Network.Application.DTOs.HobbyCategory;
using Hobbyist_Network.Application.Queries.HobbyCategory;
using Hobbyist_Network.Domain.DbContexts;
using MediatR;
using System.Collections.Generic;

namespace Hobbyist_Network.Application.Handlers.HobbyCategory
{
    public class GetHobbyCategoriesQueryHandler : RequestHandler<GetHobbyCategoriesQuery, IEnumerable<HobbyCategoryDto>>
    {
        private Hobbyist_NetworkDbContext _dbContext;

        public GetHobbyCategoriesQueryHandler(Hobbyist_NetworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override IEnumerable<HobbyCategoryDto> Handle(GetHobbyCategoriesQuery request)
        {
            var categories = _dbContext.HobbyCategories;
              
            return Mapper.Map<IEnumerable<HobbyCategoryDto>>(categories);
        }
    }
}
