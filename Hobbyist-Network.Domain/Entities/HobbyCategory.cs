using System;
using System.Collections.Generic;

namespace Hobbyist_Network.Domain.Entities
{
    public class HobbyCategory : Entity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        
        public IEnumerable<Hobby> Hobbies => _hobbies.AsReadOnly();
        public IEnumerable<Event> Events => _events.AsReadOnly();

        public HobbyCategory(Guid id, string name, string icon) : base(id)
        {
            Name = name;
            Icon = icon;
        }

        private HobbyCategory() { }

        private readonly List<Hobby> _hobbies = new List<Hobby>();
        private readonly List<Event> _events = new List<Event>();
    }
}
