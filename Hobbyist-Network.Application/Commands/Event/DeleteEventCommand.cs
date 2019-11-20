using MediatR;
using System;

namespace Hobbyist_Network.Application.Commands.Event
{
    public class DeleteEventCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
