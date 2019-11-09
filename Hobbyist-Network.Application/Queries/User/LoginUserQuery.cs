using Hobbyist_Network.Application.DTOs.User;
using MediatR;

namespace Hobbyist_Network.Application.Queries.User
{
    public class LoginUserQuery : IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
