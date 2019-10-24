using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Commands.Hobby
{
    class DeleteHobbyCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
