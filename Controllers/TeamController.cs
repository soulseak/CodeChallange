using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using CodeChallange.Models;

namespace Teamscore.Controllers
{
    public class ExportTeam
    {
        public int TeamId { get; set; }
        public String Name { get; set; }
        public int MemberId { get; set; }
        public String MemberName { get; set; }
        public int TeamScore { get; set; }

        public ExportTeam(int id, String na, int m_id, String m_na, int ts)
        {
            TeamId = id;
            Name = na;
            MemberId = m_id;
            MemberName = m_na;
            TeamScore = ts;

        }
    }
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly TeamscoreContext _TeamscoreContext;
        public TeamController(TeamscoreContext context)
        {
            _TeamscoreContext = context;
        }
        [HttpGet("[action]")]
        public IActionResult Team()
        {

            var teams = _TeamscoreContext.Teams.Include("Member");
            var matches = _TeamscoreContext.Matches.Include(t => t.Team1Id).Include(t => t.Team2Id);

            if (teams == null)
            {
                return NotFound();
            }

            List<ExportTeam> ExportTeams = new List<ExportTeam>();

            foreach (var team in teams)
            {
                ExportTeam e_team = new ExportTeam(team.TeamId, team.Name, team.Member.MemberId, team.Member.Name, 0);

                ExportTeams.Add(e_team);
            }
            int teamScore;
            foreach (var team in ExportTeams)
            {
                teamScore = 0;
                foreach (var match in matches)
                {
                    if (match.Team1Id.TeamId == team.TeamId && match.ScoreTeam1 > match.ScoreTeam2)
                    {
                        teamScore += match.ScoreTeam1 + 10;
                    }
                    else if (match.Team1Id.TeamId == team.TeamId && match.ScoreTeam1 < match.ScoreTeam2)
                    {
                        teamScore += match.ScoreTeam1 + 5;
                    }

                    if (match.Team2Id.TeamId == team.TeamId && match.ScoreTeam2 > match.ScoreTeam1)
                    {
                        teamScore += match.ScoreTeam2 + 10;
                    }
                    else if (match.Team2Id.TeamId == team.TeamId && match.ScoreTeam2 < match.ScoreTeam1)
                    {
                        teamScore += match.ScoreTeam2 + 5;
                    }
                }
                team.TeamScore = teamScore;

            }

            var json = JsonConvert.SerializeObject(ExportTeams);
            return Ok(json);
        }
        [HttpPost("[action]")]
        public IActionResult Create([FromBody] ExportTeam item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var member = _TeamscoreContext.Members.Where(m => m.MemberId == item.MemberId).First();
            
            if (member == null)
            {
                return BadRequest("Member doesnt Exist");
            }

            Team team= new Team() { TeamId = 0, Name = item.Name, Member = member };
            _TeamscoreContext.Teams.Add(team);
            _TeamscoreContext.SaveChanges();
            return Ok(item);
        }
    }
}
