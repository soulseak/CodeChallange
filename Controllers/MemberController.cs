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
            if (item == null)
            {
                return BadRequest();
            }

            _TeamscoreContext.Members.Add(item);
            _TeamscoreContext.SaveChanges();
            return Ok(item);
        }
    }
}
