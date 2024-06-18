using Microsoft.AspNetCore.Mvc;

namespace PruebaMVC.Views.Shared.Components
{
    public class IconoFiltroViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAs()
        {
            return View();
        }
    }
}
