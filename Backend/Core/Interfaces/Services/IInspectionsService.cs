using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IInspectionsService
    {
        public Task<IEnumerable<Estado>> GetEstadosAsync();
        public Task<Estado> GetEstadoByIdAsync(int id);
        public Task<Estado> EditEstadoAsync(int id, string nombre);
        public Task<Estado> PostEstadoAsync(Estado estado);
        public Task<IEnumerable<Estado>> DeleteAEstadoAsync(int id);

        public Task<IEnumerable<Inspection>> GetInspectionsAsync();
        public Task<Inspection> GetInspectionsByIdAsync(int id);
        public Task<Inspection> EditInspectionsAsync(int id, string descripcion, int statusId);
        public Task<Inspection> PostInspectionsAsync(Inspection inspection);
        public Task<IEnumerable<Inspection>> DeleteInspectionsAsync(int id);

        public Task<IEnumerable<InspectionType>> GetInspectionTypesAsync();
        public Task<InspectionType> GetInspectionTypeByIdAsync(int id);
        public Task<InspectionType> EditInspectionTypeAsync(int id, string inspectionName);
        public Task<InspectionType> PostInspectionTypeAsync(InspectionType inspectionType);
        public Task<IEnumerable<InspectionType>> DeleteInspectionTypeAsync(int id);
    }
}
