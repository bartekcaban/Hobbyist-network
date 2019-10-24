using Hobbyist_Network.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Commands.Hobby
{
    class AddHobbyCommand : IRequest
    {
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public Level Level { get; set; }
    }
}
