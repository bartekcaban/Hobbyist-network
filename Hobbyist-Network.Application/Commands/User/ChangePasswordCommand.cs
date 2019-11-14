using MediatR;
using System;

namespace Hobbyist_Network.Application.Commands.User
{
    public class ChangePasswordCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string CurrentPassword { get; set; }
    }
}
