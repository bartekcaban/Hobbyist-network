using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Commands.Contact
{
    public class MatchContactCommand: IRequest
    {
        public Guid Id { get; set; }
        public bool Approved { get; set; }
    }
}
