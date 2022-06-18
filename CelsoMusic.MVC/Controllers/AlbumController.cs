using CelsoMusic.Domain.Musica;
using CelsoMusic.Domain.Musica.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CelsoMusic.MVC.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        // GET: AlbumController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var album = await _albumRepository.GetCompleto(id);

            return View(album);
        }

        // GET: AlbumController/Create
        public ActionResult Create(Guid artistaID)
        {
            return View(new Album());
        }

        // POST: AlbumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Album album)
        {
            try
            {
                await _albumRepository.Save(album);

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var album = await _albumRepository.Get(id);

            return View(album);
        }

        // POST: AlbumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Album album)
        {
            try
            {
                await _albumRepository.Update(album);

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var album = await _albumRepository.Get(id);

            return View(album);
        }

        // POST: AlbumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Album album)
        {
            try
            {
                await _albumRepository.Delete(album);

                return RedirectToAction(nameof(ArtistaController.Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
