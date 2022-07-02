using CelsoMusic.Application.Musica.Handler.Command;
using CelsoMusic.Application.Musica.Handler.Query;
using CelsoMusic.Application.Musica.Service.Interfaces;
using MediatR;

namespace CelsoMusic.Application.Musica.Handler
{
    public class AlbumHandler : IRequestHandler<CriarAlbumCommand, CriarAlbumCommandResponse>,
                                IRequestHandler<GetAllAlbumQuery, GetAllAlbumQueryResponse>
    {
        private readonly IAlbumService _albumService;

        public AlbumHandler(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<CriarAlbumCommandResponse> Handle(CriarAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await _albumService.Criar(request.Album);

            return new CriarAlbumCommandResponse(result);
        }

        public async Task<GetAllAlbumQueryResponse> Handle(GetAllAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await _albumService.ObterTodos();

            return new GetAllAlbumQueryResponse(result);
        }
    }
}
