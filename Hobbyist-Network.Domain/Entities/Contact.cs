using System;

namespace Hobbyist_Network.Domain.Entities
{
    public class Contact : Entity
    {
        public DateTime Date { get; set; }
        public bool Approved { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public User MatchedUser { get; set; }
        public Guid MatchedUserId { get; set; }

        public Contact(Guid id, Guid userId, Guid matchedUserId, bool approved) : base(id)
        {
            Date = DateTime.UtcNow;
            Approved = approved;
            UserId = userId;
            MatchedUserId = matchedUserId;
        }

        public void Delete()
        {
            Approved = false;
        }

        private Contact() { }
    }
}
