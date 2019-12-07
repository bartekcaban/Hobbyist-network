using Hobbyist_Network.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Queries.User
{
    public class GetUsersQuery : IRequest<IEnumerable<UserDto>>
    {
        public Guid Id { get; set; }
    }
}
