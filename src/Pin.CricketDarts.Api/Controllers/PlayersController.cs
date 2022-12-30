using Microsoft.AspNetCore.Mvc;
using Pin.CricketDarts.Core.Interfaces.Services;
using Pin.CricketDarts.Shared;

namespace Pin.CricketDarts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var players = await _playerService.GetByIdAsync(id);

            return Ok(players);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _playerService.GetAllAsync();

            return Ok(players);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(PlayerRequestDto playerRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _playerService.AddAsync(playerRequestDto);
            return Ok("Player added!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(PlayerRequestDto playerRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerResponseDto = await _playerService.UpdateAsync(playerRequestDto);
            return Ok(playerResponseDto);
        }
    }
}
