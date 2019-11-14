using Hobbyist_Network.Application.DTOs.HobbyCategory;
using MediatR;
using System.Collections.Generic;

namespace Hobbyist_Network.Application.Queries.HobbyCategory
{
    public class GetHobbyCategoriesQuery : IRequest<IEnumerable<HobbyCategoryDto>>
    {
    }
}
