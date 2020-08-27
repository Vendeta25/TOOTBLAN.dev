using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using FARTSLAM.Models.Entities;

namespace FARTSLAM.Data
{
    public class FARTSLAMDBContext: DbContext
    {
        public DbSet<PitcherProjection> PitcherProjections { get; set; }
        public DbSet<HitterProjection> HitterProjections { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<SeasonAverage> SeasonAverages { get; set; }
    }
}



