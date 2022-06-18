using CelsoMusic.Domain.Musica;
using CelsoMusic.Domain.Musica.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CelsoMusic.MVC.Controllers
{
    public class ArtistaController : Controller
    {
        private readonly IArtistaRepository _artistaRepository;

        public ArtistaController(IArtistaRepository artistaRepository)
        {
            _artistaRepository = artistaRepository;
        }

        // GET: ArtistaController
        public async Task<ActionResult> Index()
        {
            var artistas = (await _artistaRepository.GetAll()).OrderBy(a => a.Nome);

            return View(artistas);
        }

        // GET: ArtistaController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var artista = await _artistaRepository.GetCompleto(id);

            return View(artista);
        }

        // GET: ArtistaController/Create
        public ActionResult Create()
        {
            return View(new Artista());
        }

        // POST: ArtistaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Artista artista)
        {
            try
            {
                await _artistaRepository.Save(artista);

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtistaController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var artista = await _artistaRepository.Get(id);

            return View(artista);
        }

        // POST: ArtistaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Artista artista)
        {
            try
            {
                await _artistaRepository.Update(artista);

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtistaController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var artista = await _artistaRepository.Get(id);

            return View(artista);
        }

        // POST: ArtistaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Artista artista)
        {
            try
            {
                await _artistaRepository.Delete(artista);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
