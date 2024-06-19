using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;
using System.Xml.Linq;

namespace PruebaMVC.Controllers
{
   public class ListasCancionesController
   (IGenericRepositorio<ListasCancione> context,
       IGenericRepositorio<Cancione> contextCanciones,
       IGenericRepositorio<Lista> contextListas): Controller
   {

    // GET: ListasCanciones
    public async Task<IActionResult> Index()
    {
        var elemento = await context.DameTodos();

        foreach (var item in elemento)
        {
            item.Canciones = await contextCanciones.DameUno((int)item.CancionesId);
            item.Listas = await contextListas.DameUno((int)item.ListasId);
        }

        return View(elemento);
    }

    // GET: ListasCanciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listasCancione = await context.DameUno((int)id);
            return View(listasCancione);
        }

        // GET: ListasCanciones/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CancionesId"] = new SelectList(await context.DameTodos(), "Id", "Id");
            ViewData["ListasId"] = new SelectList(await context.DameTodos(), "Id", "Id");
            return View();
        }

        // POST: ListasCanciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListasId,CancionesId")] ListasCancione listasCancione)
        {
            if (ModelState.IsValid)
            {
                await context.Agregar(listasCancione);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CancionesId"] = new SelectList(await context.DameTodos(), "Id", "Id", listasCancione.CancionesId);
            ViewData["ListasId"] = new SelectList(await context.DameTodos(), "Id", "Id", listasCancione.ListasId);
            return View(listasCancione);
        }

        // GET: ListasCanciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listasCancione = await context.DameUno((int)id);
            ViewData["CancionesId"] = new SelectList(await context.DameTodos(), "Id", "Id", listasCancione.CancionesId);
            ViewData["ListasId"] = new SelectList(await context.DameTodos(), "Id", "Id", listasCancione.ListasId);
            return View(listasCancione);
        }

        // POST: ListasCanciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListasId,CancionesId")] ListasCancione listasCancione)
        {
            if (id != listasCancione.Id)
            {
                return NotFound();
            }
         
            await context.Modificar(id,listasCancione);
            ViewData["CancionesId"] = new SelectList(await context.DameTodos(), "Id", "Id", listasCancione.CancionesId);
            ViewData["ListasId"] = new SelectList(await context.DameTodos(), "Id", "Id", listasCancione.ListasId);
            return View(listasCancione);
        }

        // GET: ListasCanciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listasCancione = await context.DameUno((int)id);
            return View(listasCancione);
        }

        // POST: ListasCanciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listasCancione = await context.DameUno(id);
            await context.Borrar(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ListasCancioneExists(int id)
        {
            var elemento = await context.DameTodos();
            return elemento.Exists(e=>e.Id==id);
        }
    }
}
