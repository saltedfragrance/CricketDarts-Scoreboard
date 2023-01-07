using Microsoft.AspNetCore.Mvc;
using Pin.CricketDarts.Core.Interfaces.Services;
using Pin.CricketDarts.Shared;

namespace Pin.CricketDarts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : Controller
    {
        private readonly ITournamentService _tournamentService;

        public TournamentsController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTournaments()
        {
            var tournaments = await _tournamentService.GetAllAsync();

            return Ok(tournaments);
        }

        [HttpPost]
        public async Task<IActionResult> AddTournament(TournamentRequestDto tournamentRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _tournamentService.AddAsync(tournamentRequestDto);
            return Ok("Tournament added!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTournament(TournamentRequestDto tournamentRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _tournamentService.UpdateAsync(tournamentRequestDto);
            return Ok("Tournament updated!");
        }
    }
}
