using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabuProject.DTOs.Languages;
using TabuProject.Entities;
using TabuProject.Exceptions;
using TabuProject.Services.Abstracts;

namespace TabuProject.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        readonly IMapper _mapper; 
        readonly ILanguageService _service;
        public LanguagesController(ILanguageService service, IMapper mapper)
        {
            _mapper = mapper; 
            _service = service;
        }
        [HttpGet("{code}")]
        public async Task<IActionResult> GetOne(string? code)
        {
            var language = await _service.GetByCodeAsync(code);
            return Ok(language);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateLanguageDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPatch("{code}")]
        public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
        {
            var language = await _service.GetByCodeAsync(code);

            if (language == null)
                return NotFound();

            var isUpdate = await _service.UpdateAsync(dto, code);

            if (isUpdate)
                return Ok(language);
            else
                return BadRequest();
        }
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string? code)
        {
            await _service.DeleteAsync(code);
            return Ok(); 
        }
    }
}
