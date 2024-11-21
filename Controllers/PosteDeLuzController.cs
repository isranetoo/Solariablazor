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
        public IActionResult AjusteInteligente(bool presencaDetectada)
        {
        
            _posteDeLuzService.AjustarInteligente(presencaDetectada);
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public IActionResult MonitoramentoBateria(int cargaBateria)
        {
          
            _posteDeLuzService.MonitorarBateria(cargaBateria);
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
