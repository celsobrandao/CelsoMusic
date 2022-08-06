using CelsoMusic.Application.Usuario.DTO;
using CelsoMusic.Application.Usuario.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CelsoMusic.API.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("Criar")]
        public async Task<IActionResult> Criar(PlaylistInputDTO dto, Guid usuarioID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _playlistService.Criar(dto, usuarioID);

            return Created($"/{result.ID}", result);
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar(PlaylistUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _playlistService.Atualizar(dto);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Remover")]
        public async Task<IActionResult> Remover(Guid playlistID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _playlistService.Remover(playlistID);

            return NoContent();
        }
    }
}
