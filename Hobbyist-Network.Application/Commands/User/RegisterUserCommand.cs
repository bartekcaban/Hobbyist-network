using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Commands.User
{
    public class RegisterUserCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
