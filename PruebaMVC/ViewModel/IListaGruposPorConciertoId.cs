using PruebaMVC.Models;

namespace PruebaMVC.ViewModel
{
    public interface IListaGruposPorConciertoId
    {
        public Task<List<ConciertoConGruposcs>> dameGrupos(int ConciertoId);
    }
}
