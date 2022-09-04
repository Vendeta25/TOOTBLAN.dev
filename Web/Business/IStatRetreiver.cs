using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TOOTBLAN.Models;

namespace TOOTBLAN.Business
{
    public interface IStatRetreiver
    {

        public Task<List<TeamListItem>> GetTeamsForYear(int year);

        public Task<List<PlayerListItem>> GetPlayersForTeam(int teamId, int year, bool pitcher);

        public Task<Player> GetPlayer(int playerId);

        public Task<List<Hitter>> GetHitterData(int playerId, int year);

        public Task<List<Pitcher>> GetPitcherData(int playerId, int year);

        public Hitter CombineHitterData(List<Hitter> teams);
        public Pitcher CombinePitcherData(List<Pitcher> teams);


    }
}
