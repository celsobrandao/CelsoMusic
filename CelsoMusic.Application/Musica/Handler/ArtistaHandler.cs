using CelsoMusic.Application.Musica.Handler.Command;
using CelsoMusic.Application.Musica.Handler.Query;
using CelsoMusic.Application.Musica.Service.Interfaces;
using MediatR;

namespace CelsoMusic.Application.Musica.Handler
{
    public class ArtistaHandler : IRequestHandler<CriarArtistaCommand, CriarArtistaCommandResponse>,
                                  IRequestHandler<AtualizarArtistaCommand, AtualizarArtistaCommandResponse>,
                                  IRequestHandler<RemoverArtistaCommand, RemoverArtistaCommandResponse>,
                                  IRequestHandler<GetAllArtistaQuery, GetAllArtistaQueryResponse>,
                                  IRequestHandler<GetArtistaQuery, GetArtistaQueryResponse>
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

        public async Task<AtualizarArtistaCommandResponse> Handle(AtualizarArtistaCommand request, CancellationToken cancellationToken)
        {
            var result = await _artistaService.Atualizar(request.Artista);

            return new AtualizarArtistaCommandResponse(result);
        }

        public async Task<RemoverArtistaCommandResponse> Handle(RemoverArtistaCommand request, CancellationToken cancellationToken)
        {
            await _artistaService.Remover(request.ID);

            return new RemoverArtistaCommandResponse();
        }

        public async Task<GetAllArtistaQueryResponse> Handle(GetAllArtistaQuery request, CancellationToken cancellationToken)
        {
            var result = await _artistaService.ObterTodos();

            return new GetAllArtistaQueryResponse(result);
        }

        public async Task<GetArtistaQueryResponse> Handle(GetArtistaQuery request, CancellationToken cancellationToken)
        {
            var result = await _artistaService.ObterPorID(request.ArtistaID);

            return new GetArtistaQueryResponse(result);
        }
    }
}
