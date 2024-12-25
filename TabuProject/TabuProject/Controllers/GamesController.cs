using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TabuProject.DTOs.Games;
using TabuProject.Services.Abstracts;

namespace TabuProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        readonly IGameService _service;
        readonly IMemoryCache _cache; 
        public GamesController(IGameService service, IMemoryCache cache)
        {
            _cache = cache; 
            _service = service; 
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(_cache.Get(key));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Set(string key, string value)
        {
            _cache.Set<string>(key, value, DateTime.Now.AddSeconds(20)); 
            return Ok( );
        }
        [HttpGet("Start/{id}")]
        public async Task<IActionResult> Start(Guid id)
        {
            return Ok(await _service.Start(id));
        }

    }
}
