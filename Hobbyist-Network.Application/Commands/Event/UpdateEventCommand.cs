﻿using MediatR;
using System;

namespace Hobbyist_Network.Application.Commands.Event
{
    public class UpdateEventCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid CategoryId { get; set; }
    }
}
