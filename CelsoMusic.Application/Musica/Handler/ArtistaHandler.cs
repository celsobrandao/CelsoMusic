using CelsoMusic.Application.Musica.Handler.Command;
using CelsoMusic.Application.Musica.Handler.Query;
using CelsoMusic.Application.Musica.Service.Interfaces;
using MediatR;

namespace CelsoMusic.Application.Musica.Handler
{
    public class ArtistaHandler : IRequestHandler<CriarArtistaCommand, CriarArtistaCommandResponse>,
                                  IRequestHandler<GetAllArtistaQuery, GetAllArtistaQueryResponse>
    {
        private readonly IArtistaService _artistaService;

        public ArtistaHandler(IArtistaService artistaService)
        {
            _artistaService = artistaService;
        }

        public async Task<CriarArtistaCommandResponse> Handle(CriarArtistaCommand request, CancellationToken cancellationToken)
        {
            var result = await _artistaService.Criar(request.Artista);

            return new CriarArtistaCommandResponse(result);
        }

        public async Task<GetAllArtistaQueryResponse> Handle(GetAllArtistaQuery request, CancellationToken cancellationToken)
        {
            var result = await _artistaService.ObterTodos();

            return new GetAllArtistaQueryResponse(result);
        }
    }
}
