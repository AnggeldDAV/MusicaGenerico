using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVC.Views.Shared.Components
{
    public class ComboBoxGruposViewComponent(IGenericRepositorio<Grupo> _contextGrupos) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _contextGrupos.DameTodos());
        }
    }
}
