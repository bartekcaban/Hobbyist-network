using System;

namespace Hobbyist_Network.Domain.Entities
{
    public class Event : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User Organiser { get; set; }
        public Guid OrganiserId { get; set; }
        public HobbyCategory Category { get; set; }
        public Guid CategoryId { get; set; }

        public Event(Guid id, string name, string description, string localization, DateTime startDate, DateTime endDate, Guid organiserId, Guid categoryId) : base(id)
        {
            Name = name;
            Description = description;
            Localization = localization;
            StartDate = startDate;
            EndDate = endDate;
            OrganiserId = organiserId;
            CategoryId = categoryId;
        }

        private Event() { }
    }
}
