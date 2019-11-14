using Hobbyist_Network.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
    }
}
