using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallange.Models
{

    public class Match
    {
        public int MatchId { get; set; }
        public Team Team1Id { get; set; }
        public Team Team2Id { get; set; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
    }
}
