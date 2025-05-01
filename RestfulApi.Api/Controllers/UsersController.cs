using Microsoft.AspNetCore.Mvc;
using RestfulApi.Application.DTOs;
using RestfulApi.Application.Interfaces;

namespace RestfulApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto dto)
        { 
          await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto dto)
        { 
            if (id != dto.Id) return BadRequest();  
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            await _service.DeleteAsync(id); 
            return NoContent(); 
        }
    }
}
