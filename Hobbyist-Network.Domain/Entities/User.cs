using Hobbyist_Network.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public IEnumerable<Contact> Contacts => _contacts.AsReadOnly();
        public IEnumerable<Contact> MatchedContacts => _matchedContacts.AsReadOnly();
        public IEnumerable<Hobby> Hobbies => _hobbies.AsReadOnly();
        public IEnumerable<Event> OrganisedEvents => _organisedEvents.AsReadOnly();

        public User(Guid id, string firstName, string lastName, string password, string email) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
        }

        private User() { }

        private readonly List<Contact> _contacts = new List<Contact>();
        private readonly List<Contact> _matchedContacts = new List<Contact>();
        private readonly List<Hobby> _hobbies = new List<Hobby>();
        private readonly List<Event> _organisedEvents = new List<Event>();
    }
}
