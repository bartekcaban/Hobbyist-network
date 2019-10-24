using Hobbyist_Network.Application.DTOs.Hobby;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Queries.Hobby
{
    public class GetHobbiesByUserIdQuery : IRequest<IList<HobbyDto>>
    {
        public Guid UserId { get; set; }
    }
}
