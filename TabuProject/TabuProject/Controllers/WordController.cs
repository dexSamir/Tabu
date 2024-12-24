using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using TabuProject.DTOs.Word;
using TabuProject.Exceptions;
using TabuProject.Services.Abstracts;

namespace TabuProject.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        readonly IWordService _service;
        public WordController(IWordService service)
        {
            _service = service; 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            try
            {
                var word = await _service.FindById(id);
                return Ok(word); 
            }
            catch (Exception ex)
            {
                if(ex is IBaseException BEX)
                {
                    return StatusCode(BEX.StatusCode, new
                    {
                        Message = BEX.ErrorMessage,
                        StatusCode = BEX.StatusCode
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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WordCreateDto dto) 
        {
            try
            {
                await _service.CreateAsync(dto);
                return Ok(); 
            }
            catch (Exception ex)
            {
                if(ex is IBaseException BEX)
                {
                    return StatusCode(BEX.StatusCode, new
                    {
                        Message = BEX.ErrorMessage,
                        StatusCode = BEX.StatusCode
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
        [HttpPost("[Action]")]
        public async Task<IActionResult> CreateMany(List<WordCreateDto> dto)
        {
            try
            {
                foreach (var item in dto)
                {
                    await _service.CreateAsync(item);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is IBaseException BEX)
                {
                    return StatusCode(BEX.StatusCode, new
                    {
                        Message = BEX.ErrorMessage,
                        StatusCode = BEX.StatusCode
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
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int? id, WordUpdateDto dto)
        {
            var word = await _service.FindById(id); 
            var isUpdate = await _service.UpdateAsync(id, dto);
            if (isUpdate)
                return Ok(word);
            else
                return BadRequest();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            await _service.DeleteAysnc(id); 
            return Ok();
        }
    }
}
