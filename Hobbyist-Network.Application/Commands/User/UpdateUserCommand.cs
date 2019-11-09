using Hobbyist_Network.Domain.Enums;
using MediatR;
using System;

namespace Hobbyist_Network.Application.Commands.User
{
    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
    }
}
