using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using CodeChallange.Models;


namespace Team.Controllers
{
    
    public class ExportMatch
    {
        public int MatchID { get; set; }
        public int TeamID1 { get; set; }
        public String TeamName1 { get; set; }
        public int TeamID2 { get; set; }
        public String TeamName2 { get; set; }
        public int TeamScore1 { get; set; }
        public int TeamScore2 { get; set; }


        public ExportMatch(int id, int tid1, String tna1, int tid2, String tna2, int ts1, int ts2)
        {
            MatchID = id;
            TeamID1 = tid1;
            TeamName1 = tna1;
            TeamID2 = tid2;
            TeamName2 = tna2;
            TeamScore1 = ts1;
            TeamScore2 = ts2;
        }
    }

    [Route("api/[controller]")]
    public class MatchController : Controller
    {

        private readonly TeamscoreContext _TeamscoreContext;
        public MatchController(TeamscoreContext context)
        {
            _TeamscoreContext = context;
        }

        

        [HttpGet("[action]")]
        public IActionResult Match()
        {

            var Matches = _TeamscoreContext.Matches.Include(m => m.Team1Id).Include(m => m.Team2Id);

            if (Matches == null)
            {
                return NotFound();
            }

            List<ExportMatch> ExportMatches = new List<ExportMatch>();
            foreach (var match in Matches)
            {
                ExportMatch e_match = new ExportMatch(match.MatchId, match.Team1Id.TeamId, match.Team1Id.Name, match.Team2Id.TeamId, match.Team2Id.Name, match.ScoreTeam1, match.ScoreTeam2);

                ExportMatches.Add(e_match);
            }

            var json = JsonConvert.SerializeObject(ExportMatches);
            return Ok(json);
        }

    }
}