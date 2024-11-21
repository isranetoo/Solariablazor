using Microsoft.AspNetCore.Mvc;
using Solaria.Models;
using Solaria.Services;

namespace Solaria.Controllers
{
    public class PosteDeLuzController : Controller
    {
        private readonly PosteDeLuzService _posteDeLuzService;

        public PosteDeLuzController(PosteDeLuzService posteDeLuzService)
        {
            _posteDeLuzService = posteDeLuzService;
        }

        public IActionResult Index()
        {
            var posteDeLuz = _posteDeLuzService.ObterPosteDeLuz();
            return View(posteDeLuz);
        }

        [HttpPost]
        public IActionResult AjusteInteligente()
        {
            _posteDeLuzService.AjustarInteligente();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MonitoramentoBateria()
        {
            _posteDeLuzService.MonitorarBateria();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ManutencaoPreventiva()
        {
            _posteDeLuzService.RealizarManutencao();
            return RedirectToAction("Index");
        }
    }
}
