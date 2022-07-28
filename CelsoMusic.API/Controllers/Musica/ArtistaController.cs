using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Musica.Handler.Command;
using CelsoMusic.Application.Musica.Handler.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CelsoMusic.API.Controllers.Musica
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public async Task<IActionResult> Criar(ArtistaInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CriarArtistaCommand(dto));

            return Created($"/{result.Artista.ID}", result);
        }
    }
}
