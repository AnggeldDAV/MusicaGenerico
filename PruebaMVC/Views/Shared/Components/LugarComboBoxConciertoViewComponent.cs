using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVC.Views.Shared.Components
{
    public class LugarComboBoxConciertoViewComponent(IGenericRepositorio<Concierto> _contextConcierto) :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var concierto = await _contextConcierto.DameTodos();
            List<Concierto> LugaresDistintos = concierto.GroupBy(l => l.Lugar).Select(ld => ld.First()).ToList();

            return View(LugaresDistintos);
        }
    }
}
