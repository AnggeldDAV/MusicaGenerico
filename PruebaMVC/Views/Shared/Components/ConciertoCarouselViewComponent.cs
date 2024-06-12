using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVC.Views.Shared.Componets
{
    public class ConciertoCarouselViewComponent(IGenericRepositorio<Concierto> _contextConcierto) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var concierto = await _contextConcierto.DameUno((int)Id);
            List<Concierto> laLista = new List<Concierto>();
            laLista.Add(concierto);
            return View(laLista);
        }
    }
}
