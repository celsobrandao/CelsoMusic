using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Musica.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CelsoMusic.API.Controllers.Musica
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        private readonly IArtistaService _artistaService;

        public ArtistaController(IArtistaService artistaService)
        {
            _artistaService = artistaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _artistaService.ObterTodos());
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ArtistaInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _artistaService.Criar(dto);

            return Created($"/{result.ID}", result);
        }
    }
}
