using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Musica.Handler.Command;
using CelsoMusic.Application.Musica.Handler.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CelsoMusic.API.Controllers.Musica
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost("{artistaID}")]
        public async Task<IActionResult> Criar(AlbumInputDTO dto, Guid artistaID)
        {
            var result = await _mediator.Send(new CriarAlbumCommand(dto, artistaID));

            return Created($"{result.Album.ID}", result.Album);
        }
    }
}
