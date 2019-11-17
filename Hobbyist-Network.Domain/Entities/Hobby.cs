using Hobbyist_Network.Domain.Enums;
using System;

namespace Hobbyist_Network.Domain.Entities
{
    public class Hobby : Entity
    {
        public string Description { get; set; }
        public HobbyCategory Category { get; set; }
        public Guid CategoryId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Level Level { get; set; }

        public Hobby(Guid id, string description, Guid categoryId, Guid userId, Level level) : base(id)
        {
            Description = description;
            CategoryId = categoryId;
            UserId = userId;
            Level = level;
        }

        public void Update(string description, Guid categoryId, Level level)
        {
            Description = description;
            CategoryId = categoryId;
            Level = level;
        }

        /*protected override Dictionary<Level, string> LevelDictionary => levelDictionary;

        private readonly Dictionary<Level, string> levelDictionary = new Dictionary<Level, string>()
        {
            {Level.Beginner, "BEG" },
            {Level.Intermediate, "INT" },
            {Level.Advanced, "ADV" },
            {Level.Proffesional, "PRO" }
        };*/

        private Hobby() { }
    }
}
