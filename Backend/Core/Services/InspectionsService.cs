using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class InspectionsService: IInspectionsService
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IInspectionTypeRepository _inspectionTypeRepository;

        public InspectionsService(IEstadoRepository estadoRepository,
            IInspectionRepository inspectionRepository,
            IInspectionTypeRepository inspectionTypeRepository)
        {
            _estadoRepository = estadoRepository;
            _inspectionRepository = inspectionRepository;
            _inspectionTypeRepository = inspectionTypeRepository;
        }

        public async Task<IEnumerable<Estado>> GetEstadosAsync() => await _estadoRepository.GetEstadosAsync();
        public async Task<Estado> GetEstadoByIdAsync(int id) => await _estadoRepository.GetEstadoByIdAsync(id);
        public async Task<Estado> EditEstadoAsync(int id, string nombre) => await _estadoRepository.EditEstadoAsync(id, nombre);
        public async Task<Estado> PostEstadoAsync(Estado estado) => await _estadoRepository.PostEstadoAsync(estado);
        public async Task<IEnumerable<Estado>> DeleteAEstadoAsync(int id) => await _estadoRepository.DeleteEstadoAsync(id);

        public async Task<IEnumerable<Inspection>> GetInspectionsAsync() => await _inspectionRepository.GetInspectionAsync();
        public async Task<Inspection> GetInspectionsByIdAsync(int id) => await _inspectionRepository.GetInspectionByIdAsync(id);
        public async Task<Inspection> EditInspectionsAsync(int id, string descripcion, int statusId) => await _inspectionRepository.EditInspectionAsync(id, descripcion, statusId);
        public async Task<Inspection> PostInspectionsAsync(Inspection inspection) => await _inspectionRepository.PostInspectionAsync(inspection);
        public async Task<IEnumerable<Inspection>> DeleteInspectionsAsync(int id) => await _inspectionRepository.DeleteInspectionAsync(id);

        public async Task<IEnumerable<InspectionType>> GetInspectionTypesAsync() => await _inspectionTypeRepository.GetInspectionTypeAsync();
        public async Task<InspectionType> GetInspectionTypeByIdAsync(int id) => await _inspectionTypeRepository.GetInspectionTypeByIdAsync(id);
        public async Task<InspectionType> EditInspectionTypeAsync(int id, string inspectionName) => await _inspectionTypeRepository.EditInspectionTypeAsync(id, inspectionName);
        public async Task<InspectionType> PostInspectionTypeAsync(InspectionType inspectionType) => await _inspectionTypeRepository.PostInspectionTypeAsync(inspectionType);
        public async Task<IEnumerable<InspectionType>> DeleteInspectionTypeAsync(int id) => await _inspectionTypeRepository.DeleteInspectionTypeAsync(id);

    }
}
