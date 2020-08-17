namespace MLBApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MLBApp.Models.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<MLBApp.Data.FARTSLAMDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MLBApp.Data.FARTSLAMDBContext context)
        {
            var player = new Player() { 
                FirstName="Joe",
                LastName="Random",
                TeamID = 10000
            };
            context.Players.Add(player);
            context.SaveChanges();

            var team = new Team()
            {
                Name = "Test Team",
                ID = 10000
            };
            context.Teams.Add(team);
            context.SaveChanges();

        }
    }
}
