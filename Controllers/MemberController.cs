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

    public class ExportMember
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
       


        public ExportMember(int id, String mna1)
        {
            MemberId = id;
            Name = mna1;
        }
    }

    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly TeamscoreContext _TeamscoreContext;
        public MemberController(TeamscoreContext context)
        {
            _TeamscoreContext = context;
        }


        [HttpGet("[action]")]
        public IActionResult Member()
        {

            var members = _TeamscoreContext.Members;

            if (members == null)
            {
                return NotFound();
            }

            return new ObjectResult(members);
        }
        [HttpPost("[action]")]
        public IActionResult Create([FromBody] Member item)
        {
            if (item == null || item.Name == null)
            {
                return BadRequest();
            }
            if(_TeamscoreContext.Members.Where(m => m.Name == item.Name) != null)
            {
                return BadRequest("Member already Exists");
            }

            _TeamscoreContext.Members.Add(item);
            _TeamscoreContext.SaveChanges();
            return Ok(item);
        }
    }
}
