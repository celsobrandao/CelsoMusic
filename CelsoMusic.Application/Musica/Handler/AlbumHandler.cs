﻿using CelsoMusic.Application.Musica.Handler.Command;
using CelsoMusic.Application.Musica.Handler.Query;
using CelsoMusic.Application.Musica.Service.Interfaces;
using MediatR;

namespace CelsoMusic.Application.Musica.Handler
{
    public class AlbumHandler : IRequestHandler<CriarAlbumCommand, CriarAlbumCommandResponse>,
                                IRequestHandler<AtualizarAlbumCommand, AtualizarAlbumCommandResponse>,
                                IRequestHandler<RemoverAlbumCommand, RemoverAlbumCommandResponse>,
                                IRequestHandler<GetAllAlbumQuery, GetAllAlbumQueryResponse>,
                                IRequestHandler<GetAlbumQuery, GetAlbumQueryResponse>
    {
        private readonly IAlbumService _albumService;

        public AlbumHandler(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<CriarAlbumCommandResponse> Handle(CriarAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await _albumService.Criar(request.Album, request.ArtistaID);

            return new CriarAlbumCommandResponse(result);
        }

        public async Task<AtualizarAlbumCommandResponse> Handle(AtualizarAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await _albumService.Atualizar(request.Album);

            return new AtualizarAlbumCommandResponse(result);
        }

        public async Task<RemoverAlbumCommandResponse> Handle(RemoverAlbumCommand request, CancellationToken cancellationToken)
        {
            await _albumService.Remover(request.ID);

            return new RemoverAlbumCommandResponse();
        }

        public async Task<GetAllAlbumQueryResponse> Handle(GetAllAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await _albumService.ObterTodos();

            return new GetAllAlbumQueryResponse(result);
        }

        public async Task<GetAlbumQueryResponse> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await _albumService.ObterPorID(request.AlbumID);

            return new GetAlbumQueryResponse(result);
        }
    }
}
