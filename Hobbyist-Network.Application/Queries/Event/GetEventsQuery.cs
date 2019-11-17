using Hobbyist_Network.Application.DTOs.Event;
using MediatR;
using System.Collections.Generic;

namespace Hobbyist_Network.Application.Queries.Event
{
    public class GetEventsQuery : IRequest<IEnumerable<EventDto>>
    {
    }
}
