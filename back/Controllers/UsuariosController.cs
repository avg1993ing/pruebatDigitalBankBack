using Core.DTO;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IUsuariosService _usuariosService;
        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] UsuariosDto usuariosDto)
        {
            await _usuariosService.Add(usuariosDto);
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _usuariosService.GetAll());
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _usuariosService.GetById(id));
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UsuariosDto usuariosDto)
        {
            await _usuariosService.Update(usuariosDto);
            return Ok();
        }
        [HttpDelete("Delete/{idUsuario}")]
        public async Task<IActionResult> Delete(int idUsuario)
        {
            await _usuariosService.DeleteUserAsync(idUsuario);
            return Ok();
        }
    }
}
