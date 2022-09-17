using CelsoMusic.Application.Usuario.DTO;
using CelsoMusic.Application.Usuario.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CelsoMusic.API.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosPorUsuario(Guid usuarioID)
        {
            return Ok(await _playlistService.ObterTodosPorUsuario(usuarioID));
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PlaylistInputDTO dto, Guid usuarioID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _playlistService.Criar(dto, usuarioID);

            return Created($"/{result.ID}", result);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(PlaylistUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _playlistService.Atualizar(dto);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remover(Guid playlistID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _playlistService.Remover(playlistID);

            return NoContent();
        }
    }
}
