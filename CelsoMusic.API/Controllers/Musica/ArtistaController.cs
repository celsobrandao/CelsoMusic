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
    public class ArtistaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArtistaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _mediator.Send(new GetAllArtistaQuery()));
        }

        [HttpGet("{artistaID}")]
        public async Task<IActionResult> GetByID(Guid artistaID)
        {
            return Ok(await _mediator.Send(new GetArtistaQuery(artistaID)));
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ArtistaInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CriarArtistaCommand(dto));

            return Created($"/{result.Artista.ID}", result);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(ArtistaUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new AtualizarArtistaCommand(dto));

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remover(Guid artistaID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mediator.Send(new RemoverArtistaCommand(artistaID));

            return NoContent();
        }
    }
}
