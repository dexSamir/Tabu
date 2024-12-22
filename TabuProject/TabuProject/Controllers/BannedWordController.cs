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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            try
            {
                var bannedWord = await _service.FindById(id); 
                return Ok(bannedWord);
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
            var datas = await _service.GetAllAsync(); 
            return Ok(datas);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Create(BannedWordCreateDto dto, int? id)
        {
            try
            {
                await _service.CreateAsync(dto, id); 
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            await _service.DeleteAsync(id);
            return Ok(); 
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int? id, BannedWordUpdateDto dto)
        {
            var word = await _service.FindById(id); 
            bool isUpdated = await _service.UpdateAsync(id, dto);
            if (isUpdated)
                return Ok(word);
            else
                return BadRequest(); 

        }
    }
}
