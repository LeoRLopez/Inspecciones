using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IEstadoRepository
    {
        public Task<IEnumerable<Estado>> GetEstadosAsync();
        public Task<Estado> GetEstadoByIdAsync(int id);
        public Task<Estado> EditEstadoAsync(int id, string nombre);
        public Task<Estado> PostEstadoAsync(Estado estado);
        public Task<IEnumerable<Estado>> DeleteEstadoAsync(int id);
    }
}
