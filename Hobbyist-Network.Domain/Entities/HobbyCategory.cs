using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Domain.Entities
{
    public class HobbyCategory : Entity
    {
        public string Name { get; set; }

        public HobbyCategory() { }
        public HobbyCategory(Guid id) : base(id) { }
        public IEnumerable<Hobby> Hobbies => _hobbies.AsReadOnly();
        public IEnumerable<Event> Events => _events.AsReadOnly();

        public HobbyCategory(Guid id, string name) : base(id)
        {
            Name = name;
        }

        private HobbyCategory() { }

        private readonly List<Hobby> _hobbies = new List<Hobby>();
        private readonly List<Event> _events = new List<Event>();
    }
}
