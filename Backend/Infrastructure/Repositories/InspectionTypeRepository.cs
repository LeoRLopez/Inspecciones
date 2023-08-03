using Core.Data;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Validations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class InspectionTypeRepository : IInspectionTypeRepository
    {
        private readonly DataContext _context;


        public InspectionTypeRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<IEnumerable<InspectionType>> GetInspectionTypeAsync()
        {
            var estados = await _context.InspectionTypes.ToListAsync();

            return estados;
        }
        public async Task<InspectionType> GetInspectionTypeByIdAsync(int id)
        {
            var estado = await _context.FindAsync<InspectionType>(id);
            return estado;
        }

        public async Task<InspectionType> EditInspectionTypeAsync(int id, string InspectionName)
        {
            var inspectionType = await _context.FindAsync<InspectionType>(id);
            inspectionType.InspectionName = InspectionName;
            try
            {
                _context.Entry(inspectionType).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionTypeExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return inspectionType;
        }

        public async Task<InspectionType> PostInspectionTypeAsync(InspectionType inspectionType)
        {
            try
            {
                _context.InspectionTypes.Add(inspectionType);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return inspectionType;
        }

        public async Task<IEnumerable<InspectionType>> DeleteInspectionTypeAsync(int id)
        {
            if (_context.InspectionTypes == null)
            {
                return null;
            }

            try
            {
                var inspectionType = await _context.InspectionTypes.FindAsync(id);
                _context.InspectionTypes.Remove(inspectionType);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionTypeExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return await _context.InspectionTypes.ToListAsync();
        }

        private bool InspectionTypeExists(int id)
        {
            return (_context.InspectionTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
