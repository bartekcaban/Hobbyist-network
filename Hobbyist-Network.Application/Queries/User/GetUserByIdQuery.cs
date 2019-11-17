using Hobbyist_Network.Application.DTOs.User;
using MediatR;
using System;

namespace Hobbyist_Network.Application.Queries.User
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
