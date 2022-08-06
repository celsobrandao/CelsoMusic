using CelsoMusic.Application.Musica.Handler.Command;
using CelsoMusic.Application.Musica.Handler.Query;
using CelsoMusic.Application.Musica.Service.Interfaces;
using MediatR;

namespace CelsoMusic.Application.Musica.Handler
{
    public class MusicaHandler : IRequestHandler<CriarMusicaCommand, CriarMusicaCommandResponse>,
                                 IRequestHandler<AtualizarMusicaCommand, AtualizarMusicaCommandResponse>,
                                 IRequestHandler<RemoverMusicaCommand, RemoverMusicaCommandResponse>,
                                 IRequestHandler<GetAllMusicaQuery, GetAllMusicaQueryResponse>,
                                 IRequestHandler<GetMusicaQuery, GetMusicaQueryResponse>
    {
        private readonly IMusicaService _musicaService;

        public MusicaHandler(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        public async Task<CriarMusicaCommandResponse> Handle(CriarMusicaCommand request, CancellationToken cancellationToken)
        {
            var result = await _musicaService.Criar(request.Musica, request.AlbumID);

            return new CriarMusicaCommandResponse(result);
        }

        public async Task<AtualizarMusicaCommandResponse> Handle(AtualizarMusicaCommand request, CancellationToken cancellationToken)
        {
            var result = await _musicaService.Atualizar(request.Musica);

            return new AtualizarMusicaCommandResponse(result);
        }

        public async Task<RemoverMusicaCommandResponse> Handle(RemoverMusicaCommand request, CancellationToken cancellationToken)
        {
            await _musicaService.Remover(request.ID);

            return new RemoverMusicaCommandResponse();
        }

        public async Task<GetAllMusicaQueryResponse> Handle(GetAllMusicaQuery request, CancellationToken cancellationToken)
        {
            var result = await _musicaService.ObterTodos();

            return new GetAllMusicaQueryResponse(result);
        }

        public async Task<GetMusicaQueryResponse> Handle(GetMusicaQuery request, CancellationToken cancellationToken)
        {
            var result = await _musicaService.ObterPorID(request.MusicaID);

            return new GetMusicaQueryResponse(result);
        }
    }
}
