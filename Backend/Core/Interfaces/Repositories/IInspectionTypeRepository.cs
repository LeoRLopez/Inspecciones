using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IInspectionTypeRepository
    {
        public Task<IEnumerable<InspectionType>> GetInspectionTypeAsync();
        public Task<InspectionType> GetInspectionTypeByIdAsync(int id);
        public Task<InspectionType> EditInspectionTypeAsync(int id, string InspectionName);
        public Task<InspectionType> PostInspectionTypeAsync(InspectionType inspectionType);
        public Task<IEnumerable<InspectionType>> DeleteInspectionTypeAsync(int id);
    }
}
