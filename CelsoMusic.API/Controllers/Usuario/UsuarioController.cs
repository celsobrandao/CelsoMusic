using CelsoMusic.Application.Usuario.DTO;
using CelsoMusic.Application.Usuario.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CelsoMusic.API.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _usuarioService.ObterTodos());
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Criar(UsuarioInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _usuarioService.Criar(dto);

            return Created($"/{result.ID}", result);
        }

        [HttpPost]
        [Route("ValidarLogin")]
        public async Task<IActionResult> ValidarLogin(UsuarioLoginInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _usuarioService.ValidarLogin(dto);

            return result.Valido ? Ok(result.ID) : Unauthorized(result.Mensagem);
        }
    }
}
