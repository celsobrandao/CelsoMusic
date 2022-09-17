using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Musica.Handler.Command;
using CelsoMusic.Application.Musica.Handler.Query;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CelsoMusic.API.Controllers.Musica
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllAlbumQuery()));
        }

        [HttpGet("{albumID}")]
        public async Task<IActionResult> GetByID(Guid albumID)
        {
            return Ok(await _mediator.Send(new GetAlbumQuery(albumID)));
        }

        [HttpPost("{artistaID}")]
        public async Task<IActionResult> Criar(AlbumInputDTO dto, Guid artistaID)
        {
            var result = await _mediator.Send(new CriarAlbumCommand(dto, artistaID));

            return Created($"{result.Album.ID}", result.Album);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(AlbumUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new AtualizarAlbumCommand(dto));

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remover(Guid albumID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mediator.Send(new RemoverAlbumCommand(albumID));

            return NoContent();
        }
    }
}
