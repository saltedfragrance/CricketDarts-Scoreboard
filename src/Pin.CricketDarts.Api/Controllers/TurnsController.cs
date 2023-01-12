using Microsoft.AspNetCore.Mvc;
using Pin.CricketDarts.Core.Interfaces.Services;
using Pin.CricketDarts.Shared;

namespace Pin.CricketDarts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnsController : Controller
    {
        private readonly ITurnService _turnService;

        public TurnsController(ITurnService turnService)
        {
            _turnService = turnService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTurns()
        {
            var turns = await _turnService.GetAllAsync();

            return Ok(turns);
        }

        [HttpPost]
        public async Task<IActionResult> AddTurn(TurnRequestDto turnRequestDto)
        {
            await _turnService.AddAsync(turnRequestDto);
            return Ok("Turn added!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTurn(TurnRequestDto turnRequestDto)
        {
            await _turnService.UpdateAsync(turnRequestDto);
            return Ok("Turn updated!");
        }
    }
}
