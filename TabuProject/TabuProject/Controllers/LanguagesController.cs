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
            try
            {
                var language = await _service.GetByCodeAsync(code);
                return Ok(language);

            }
            catch (Exception ex)
            {
                if(ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        Message = bEx.ErrorMessage,
                        StatusCode = bEx.StatusCode
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        ex.Message
                    });
                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateLanguageDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                if(ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        StatusCode = bEx.StatusCode, 
                        Message = bEx.ErrorMessage
                    }); 
                }
                else
                {
                    return BadRequest(new
                    {
                        ex.Message
                    }); 
                }
            }
 
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
