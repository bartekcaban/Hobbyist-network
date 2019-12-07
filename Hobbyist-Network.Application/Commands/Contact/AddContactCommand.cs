using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Commands.Contact
{
    public class MatchCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid MatchedUserId { get; set; }
    }
}
