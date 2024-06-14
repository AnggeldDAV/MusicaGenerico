using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVC.Controllers
{
    public class ConciertoVistaController(IGenericRepositorio<Concierto> _contextConcierto) : Controller
    {
        public async Task<ActionResult> Index(int pagina = 0, int paginaTarjeta = 1)
        {
            var lista = (await _contextConcierto.DameTodos());
            if (pagina < 0) pagina = 0;
            if (pagina > lista.Count - 1) pagina = lista.Count - 1;
            ViewBag.Pagina = pagina;
            var concierto = lista.Take(new Range(pagina, pagina + 1)).FirstOrDefault();
            ViewBag.IdConcierto = concierto.Id;
            ViewBag.Pagina = pagina;
            ViewBag.Url = $"img/Concierto/ConciertoId{concierto.Id}.png";
            ViewBag.PaginaTarjetas = paginaTarjeta; 
            return View(lista.Take(new Range(8 * (paginaTarjeta - 1), 8 * (paginaTarjeta))));
        }
    }
}
