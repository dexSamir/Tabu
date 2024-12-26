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
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Start(Guid id)
        {
            return Ok(await _service.Start(id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Skip(Guid id)
        {
            return Ok(await _service.Skip(id));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Success(Guid id)
        {
            return Ok(_service.Success(id));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Fail(Guid id)
        {
            return Ok(_service.Fail(id));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> End(Guid id)
        {
            return Ok(_service.End(id));
        }
    }
}
