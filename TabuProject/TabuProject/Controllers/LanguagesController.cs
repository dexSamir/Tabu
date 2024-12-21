using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabuProject.DTOs.Languages;
using TabuProject.Entities;
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateLanguageDto dto)
        {
            var data = _mapper.Map<Language>(dto); 
            await _service.CreateAsync(dto);
            return Ok(data);
        }
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string? code)
        {
            await _service.DeleteAsync(code);
            return Ok(); 
        }
        [HttpPatch("{code}")]
        public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
        {
            await _service.UpdateAsync(dto, code);
            return Ok();
        }
    }
}
