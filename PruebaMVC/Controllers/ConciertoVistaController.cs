using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVC.Controllers
{
    public class ConciertoVistaController(IGenericRepositorio<Concierto> _contextConcierto) : Controller
    {
        public async Task<ActionResult> Index(int pagina = 0)
        {
            var lista = (await _contextConcierto.DameTodos());
            if (pagina < 0) pagina = 0;
            if (pagina > lista.Count) pagina = lista.Count;
            ViewBag.Pagina = pagina;
            var concierto = lista.Take(new Range(pagina, pagina + 1)).FirstOrDefault();
            ViewBag.IdConcierto = concierto.Id;
            ViewBag.Url = $"img/Concierto/ConciertoId{concierto.Id}.png";
            
            return View();
        }
    }
}
