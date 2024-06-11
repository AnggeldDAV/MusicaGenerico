using Microsoft.AspNetCore.Mvc;

namespace PruebaMVC.Controllers
{
    public class ConciertoVistaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
