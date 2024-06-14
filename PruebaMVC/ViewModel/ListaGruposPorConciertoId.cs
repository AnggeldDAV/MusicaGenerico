using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVC.ViewModel
{
    public class ListaGruposPorConciertoId(IGenericRepositorio<Concierto> _contextConcierto,
        IGenericRepositorio<ConciertosGrupo> _contextConciertoGrupo, IGenericRepositorio<Grupo> _contextGrupo) : IListaGruposPorConciertoId
    {
        public async Task<List<ConciertoConGruposcs>> dameGrupos(int ConciertoId)
        {
            var datosComponente = from c in (await _contextConcierto.DameTodos()).AsParallel()
                join gc in (await _contextConciertoGrupo.DameTodos()).AsParallel() on c.Id equals gc.ConciertosId
                join g in (await _contextGrupo.DameTodos()).AsParallel() on gc.GruposId equals g.Id
                where c.Id == ConciertoId
                select new ConciertoConGruposcs()
                {
                    Fecha = c.Fecha,
                    Genero = c.Genero,
                    Lugar = c.Lugar,
                    Titulo = c.Titulo,
                    Precio = c.Precio,
                    GruposId = gc.GruposId,
                    ConciertosId = gc.ConciertosId,
                    Nombre = g.Nombre
                };

            return datosComponente.ToList();
        }
    }
}
