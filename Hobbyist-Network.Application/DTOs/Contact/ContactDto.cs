using Hobbyist_Network.Application.DTOs.Hobby;
using Hobbyist_Network.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.DTOs.Contact
{
    public class ContactDto
    {
        public ContactDto(Guid id, Guid userId, string email, string firstName, string lastName, string phoneNumber, DateTime dateOfBirth, Gender gender, string city, string description, string instagram, string facebook, IEnumerable<HobbyDto> hobbies, DateTime date)
        {
            Id = id;
            UserId = userId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            City = city;
            Description = description;
            Instagram = instagram;
            Facebook = facebook;
            Hobbies = hobbies;
            Date = date;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
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
        public IEnumerable<HobbyDto> Hobbies { get; set; }
        public DateTime Date { get; set; }
    }
}
