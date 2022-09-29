using CelsoMusic.Application.Playlist.DTO;
using CelsoMusic.Application.Playlist.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CelsoMusic.API.Controllers.Playlist
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
        public async Task<IActionResult> Criar(PlaylistInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _playlistService.Criar(dto);

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
