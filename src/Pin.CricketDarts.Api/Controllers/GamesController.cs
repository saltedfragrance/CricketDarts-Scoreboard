using Microsoft.AspNetCore.Mvc;
using Pin.CricketDarts.Core.Interfaces.Services;
using Pin.CricketDarts.Shared;

namespace Pin.CricketDarts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Gamescontroller : Controller
    {
        private readonly IGameService _gameService;

        public Gamescontroller(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameService.GetAllAsync();

            return Ok(games);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(GameRequestDto gameRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _gameService.AddAsync(gameRequestDto);
            return Ok("Player added!");
        }
    }
}
