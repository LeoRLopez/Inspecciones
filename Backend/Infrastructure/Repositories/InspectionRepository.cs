using Core.Data;
using Core.Entities;
using Core.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.Validations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class InspectionRepository: IInspectionRepository
    {
        private readonly DataContext _context;
        private readonly FluentValidations _validator;
        public InspectionRepository(DataContext dataContext, FluentValidations validations)
        {
            _context = dataContext;
            _validator = validations;
        }

        public async Task<IEnumerable<Inspection>> GetInspectionAsync()
        {

            var inspection = await _context.Inspections.ToListAsync();
            return inspection;
        }

        public async Task<Inspection> GetInspectionByIdAsync(int id)
        {
            var inspection = await _context.FindAsync<Inspection>(id);
            return inspection;
        }

        public async Task<Inspection> EditInspectionAsync(int id, string descripcion, int statusId)
        {

            var inspection = await _context.Inspections.FindAsync(id);
            inspection.Description = descripcion;
            inspection.StatusId = statusId;

            try
            {
                ValidationResult inspectionResult = _validator.Validate(inspection, op => op.ThrowOnFailures());
                if (inspectionResult.IsValid)
                {
                    _context.Entry(inspection).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return inspection;
        }

        public async Task<Inspection> PostInspectionAsync(Inspection inspection)
        {
                ValidationResult inspectionResult = _validator.Validate(inspection, op => op.ThrowOnFailures());
            try
            {
                if (inspectionResult.IsValid)
                {
                    _context.Inspections.Add(inspection);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return inspection;
        }

        public async Task<IEnumerable<Inspection>> DeleteInspectionAsync(int id)
        {
            if (_context.Inspections == null)
            {
                return null;
            }

            try
            {
                var inspection = await _context.Inspections.FindAsync(id);
                _context.Inspections.Remove(inspection);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return await _context.Inspections.ToListAsync();
        }

        private bool InspectionExists(int id)
        {
            return (_context.Inspections?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
