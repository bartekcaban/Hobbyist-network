using Microsoft.EntityFrameworkCore;
using Hobbyist_Network.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Hobbyist_Network.Domain.Configuration;

namespace Hobbyist_Network.Domain.DbContexts
{
    public class Hobbyist_NetworkDbContext : DbContext
    {
        public Hobbyist_NetworkDbContext(DbContextOptions<Hobbyist_NetworkDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<HobbyCategory> HobbyCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new HobbyConfiguration());
            builder.ApplyConfiguration(new HobbyCategoryConfiguration());

            base.OnModelCreating(builder);
        }

    }
}
