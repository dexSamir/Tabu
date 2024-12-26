using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabuProject.DAL;
using TabuProject.DTOs.BannedWord;
using TabuProject.Exceptions;
using TabuProject.Services.Abstracts;

namespace TabuProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedWordController : ControllerBase
    {
        readonly IBannedWordService _service;
        public BannedWordController(IBannedWordService service)
        {
            _service = service; 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            await _service.DeleteAsync(id);
            return Ok(); 
        }
    }
}
