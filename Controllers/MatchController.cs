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
        public int MatchId { get; set; }
        public int Team1Id { get; set; }
        public String TeamName1 { get; set; }
        public int Team2Id { get; set; }
        public String TeamName2 { get; set; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }


        public ExportMatch(int id, int tid1, String tna1, int tid2, String tna2, int ts1, int ts2)
        {
            MatchId = id;
            Team1Id = tid1;
            TeamName1 = tna1;
            Team2Id = tid2;
            TeamName2 = tna2;
            ScoreTeam1 = ts1;
            ScoreTeam2 = ts2;
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
        [HttpPost("[action]")]
        public IActionResult Create([FromBody] ExportMatch item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var team1 = _TeamscoreContext.Teams.Where(t => t.TeamId == item.Team1Id).First();
            var team2 = _TeamscoreContext.Teams.Where(t => t.TeamId == item.Team2Id).First();

            if(team1 == null || team2 == null)
            {
                return BadRequest("Teams doesnt Exist");
            }

            Match match = new Match() { MatchId = 0, Team1Id = team1, Team2Id = team2, ScoreTeam1 = item.ScoreTeam1, ScoreTeam2 = item.ScoreTeam2 };
            _TeamscoreContext.Matches.Add(match);
            _TeamscoreContext.SaveChanges();
            return Ok(item);
        }
    }
}