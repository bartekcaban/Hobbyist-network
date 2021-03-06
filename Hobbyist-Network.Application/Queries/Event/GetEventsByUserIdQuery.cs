﻿using Hobbyist_Network.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;

namespace Hobbyist_Network.Application.Queries.Event
{
    public class GetEventsByUserIdQuery : IRequest<IEnumerable<EventDto>>
    {
        public Guid UserId { get; set; }
    }
}
