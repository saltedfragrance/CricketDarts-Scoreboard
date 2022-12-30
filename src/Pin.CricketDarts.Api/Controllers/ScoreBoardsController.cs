using Microsoft.AspNetCore.Mvc;
using Pin.CricketDarts.Core.Interfaces.Services;
using Pin.CricketDarts.Shared;

namespace Pin.CricketDarts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreBoardsController : Controller
    {
        private readonly IScoreBoardEntryService _scoreBoardEntryService;

        public ScoreBoardsController(IScoreBoardEntryService scoreBoardEntryService)
        {
            _scoreBoardEntryService = scoreBoardEntryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllScoreBoardEntries()
        {
            var scoreBoardEntries = await _scoreBoardEntryService.GetAllAsync();

            return Ok(scoreBoardEntries);
        }

        [HttpPost]
        public async Task<IActionResult> AddScoreBoardEntry(ScoreBoardEntryRequestDto scoreBoardEntryRequestDto)
        {
            await _scoreBoardEntryService.AddAsync(scoreBoardEntryRequestDto);
            return Ok("Scoreboard entry added!");
        }
    }
}
