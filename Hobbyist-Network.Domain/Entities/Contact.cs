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

        public Contact(Guid id, Guid userId, Guid matchedUserId) : base(id)
        {
            UserId = userId;
            MatchedUserId = matchedUserId;
            Approved = false;
        }

        public void Match()
        {
            Date = DateTime.UtcNow;
            Approved = true;
        }

        private Contact() { }
    }
}
