using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Musica.Handler.Command;
using CelsoMusic.Application.Musica.Handler.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CelsoMusic.API.Controllers.Musica
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MusicaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllMusicaQuery()));
        }

        [HttpGet("{musicaID}")]
        public async Task<IActionResult> GetByID(Guid musicaID)
        {
            return Ok(await _mediator.Send(new GetMusicaQuery(musicaID)));
        }

        [HttpPost("{albumID}")]
        public async Task<IActionResult> Criar(MusicaInputDTO dto, Guid albumID)
        {
            var result = await _mediator.Send(new CriarMusicaCommand(dto, albumID));

            return Created($"{result.Musica.ID}", result.Musica);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(MusicaUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new AtualizarMusicaCommand(dto));

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remover(Guid MusicaID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mediator.Send(new RemoverMusicaCommand(MusicaID));

            return NoContent();
        }
    }
}
