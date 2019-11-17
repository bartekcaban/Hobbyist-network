using Hobbyist_Network.Domain.Enums;
using MediatR;
using System;

namespace Hobbyist_Network.Application.Commands.Hobby
{
    public class AddHobbyCommand : IRequest
    {
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public Level Level { get; set; }
    }
}
