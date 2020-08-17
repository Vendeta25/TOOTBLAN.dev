using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using MLBApp.Models.Entities;

namespace MLBApp.Data
{
    public class FARTSLAMDBContext: DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}
