using FullStackFun.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackFun.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlingLeagueController : ControllerBase
    {
        private BowlingLeagueContext _bowlContext;
        
        public BowlingLeagueController(BowlingLeagueContext temp)
        {
            _bowlContext = temp;
        }
        
        [HttpGet(Name = "GetBowler")]
        public async Task<ActionResult<IEnumerable<object>>> Get()
        {
            var bowllist = await _bowlContext.Bowlers
                .Include(b => b.Team) // ✅ Include Team Data
                .Where(b => b.Team != null && (b.Team.TeamName == "Sharks" || b.Team.TeamName == "Marlins")) // ✅ Filter Teams
                .Select(b => new
                {
                    b.BowlerId,
                    b.BowlerLastName,
                    b.BowlerFirstName,
                    b.BowlerMiddleInit,
                    b.BowlerAddress,
                    b.BowlerCity,
                    b.BowlerState,
                    b.BowlerZip,
                    b.BowlerPhoneNumber,
                    b.TeamId,
                    TeamName = b.Team != null ? b.Team.TeamName : "No Team" // ✅ Return Team Name
                })
                .ToListAsync();

            return Ok(bowllist);
        }
    }
}