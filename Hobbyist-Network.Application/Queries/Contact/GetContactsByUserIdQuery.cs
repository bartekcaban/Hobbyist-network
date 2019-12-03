using Hobbyist_Network.Application.DTOs.Contact;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Queries.Contact
{
    public class GetContactsByUserIdQuery :IRequest<IEnumerable<ContactDto>>
    {
        public Guid UserId { get; set; }
    }
}
