﻿
using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;
using PruebaMVC.ViewModel;

namespace PruebaMVC.Views.Shared.Components
{
    public class TarjetaConciertoViewComponent(IGenericRepositorio<Concierto> _contextConcierto, 
        IGenericRepositorio<ConciertosGrupo> _contextConciertoGrupo, IGenericRepositorio<Grupo> _contextGrupo) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int idConcierto = 1)
        {
            Console.WriteLine("Concierto id: " + idConcierto);
            var datosComponente = await (new GruposPorConcierto(_contextConcierto,
                _contextConciertoGrupo, _contextGrupo)).dameListaDeConciertoConGrupos(idConcierto);
            ViewBag.UrlTarjeta = $"img/Concierto/ConciertoId{idConcierto.ToString()}.png";
            
            return View(datosComponente.FirstOrDefault());
        }
    }
}
