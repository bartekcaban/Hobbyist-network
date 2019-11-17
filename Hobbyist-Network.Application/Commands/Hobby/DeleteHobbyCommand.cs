using MediatR;
using System;

namespace Hobbyist_Network.Application.Commands.Hobby
{
    public class DeleteHobbyCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
