using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using TOOTBLAN.Models.Entities;

namespace TOOTBLAN.Data
{
    public class TOOTBLANDBContext: DbContext
    {
        public DbSet<PitcherProjection> PitcherProjections { get; set; }
        public DbSet<HitterProjection> HitterProjections { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<SeasonAverage> SeasonAverages { get; set; }
    }
}



