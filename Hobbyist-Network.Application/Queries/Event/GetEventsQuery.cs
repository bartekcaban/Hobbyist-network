using Hobbyist_Network.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Queries.Event
{
    public class GetEventsQuery : IRequest<IList<EventDto>>
    {
    }
}
