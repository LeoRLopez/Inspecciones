using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IInspectionRepository
    {
        public Task<IEnumerable<Inspection>> GetInspectionAsync();
        public Task<Inspection> GetInspectionByIdAsync(int id);
        public Task<Inspection> EditInspectionAsync(int id, string descripcion, int statusId);
        public Task<Inspection> PostInspectionAsync(Inspection inspection);
        public Task<IEnumerable<Inspection>> DeleteInspectionAsync(int id);
    }
}
