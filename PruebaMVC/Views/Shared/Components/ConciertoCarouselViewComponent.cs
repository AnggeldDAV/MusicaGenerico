using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVC.Views.Shared.Componets
{
    public class ConciertoCarouselViewComponent(IGenericRepositorio<Concierto> _contextConcierto) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var concierto = await _contextConcierto.DameTodos();
            
            return View(concierto);
        }
    }
}
