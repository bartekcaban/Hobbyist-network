using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Domain.Entities
{
    public class Contact : Entity
    {
        public DateTime Date { get; set; }
        public User User1 { get; set; }
        public Guid User1Id { get; set; }
        public User User2 { get; set; }
        public Guid User2Id { get; set; }

        public Contact(Guid id, Guid user1Id, Guid user2Id) : base(id)
        {
            Date = DateTime.UtcNow;
            User1Id = user1Id;
            User2Id = user2Id;
        }

        private Contact() { }
    }
}
