using Hobbyist_Network.Application.DTOs.HobbyCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Queries.HobbyCategory
{
    public class GetHobbyCategoriesQuery : IRequest<IList<HobbyCategoryDto>>
    {
    }
}
