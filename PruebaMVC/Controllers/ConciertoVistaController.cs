using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVC.Controllers
{
    public class ConciertoVistaController(IGenericRepositorio<Concierto> _contextConcierto) : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View(await _contextConcierto.DameTodos());
        }
    }
}
