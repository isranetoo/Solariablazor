using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solaria.Models;
using Solaria.Services;

namespace SolariaBlazor.Views
{
    public class IndexModel(PosteDeLuzService posteDeLuzService) : PageModel
    {
        private readonly PosteDeLuzService _posteDeLuzService = posteDeLuzService;

        public required PosteDeLuz PosteDeLuz { get; set; }
        [BindProperty]
        public bool PresencaDetectada { get; set; }
        [BindProperty]
        public int CargaBateria { get; set; }

        public void OnGet()
        {
            PosteDeLuz = _posteDeLuzService.ObterPosteDeLuz();
        }

        public IActionResult OnPostAjusteInteligente()
        {
            _posteDeLuzService.AjustarInteligente(PresencaDetectada);
            return RedirectToPage(); 
        }

        public IActionResult OnPostMonitoramentoBateria()
        {
            _posteDeLuzService.MonitorarBateria(CargaBateria);
            return RedirectToPage(); 
        }

        public IActionResult OnPostManutencaoPreventiva()
        {
            _posteDeLuzService.RealizarManutencao();
            return RedirectToPage(); 
        }
    }
}
