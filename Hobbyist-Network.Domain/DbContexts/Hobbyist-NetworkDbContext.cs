using Microsoft.EntityFrameworkCore;
using Hobbyist_Network.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Domain.DbContexts
{
    class Hobbyist_NetworkDbContext : DbContext
    {
        public Hobbyist_NetworkDbContext(DbContextOptions<Hobbyist_NetworkDbContext> dbContextOptions): base(dbContextOptions)
        {

        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            base.OnModelCreating(builder);
        }

    }
}
