using AutoMapper;
using Core.Data;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly DataContext _context;

        public EstadoRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IEnumerable<Estado>> GetEstadosAsync()
        {
            var estados = await _context.Estados.ToListAsync();
            return estados;
        }

        public async Task<Estado> GetEstadoByIdAsync(int id)
        {
            var estado = await _context.FindAsync<Estado>(id);
            return estado;
        }

        public async Task<Estado> EditEstadoAsync(int id, string nombre)
        {
            var estado = await _context.Estados.FindAsync(id);
            estado.EstadoNombre = nombre;
            try
            {
                _context.Entry(estado).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return estado;
        }

        public async Task<Estado> PostEstadoAsync(Estado estado)
        {
            try
            {
                _context.Estados.Add(estado);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return estado;
        }

        public async Task<IEnumerable<Estado>> DeleteEstadoAsync(int id) 
        {
            if (_context.Estados == null)
            {
                return null;
            }

            try
            {
                var estado = await _context.Estados.FindAsync(id);
                 _context.Estados.Remove(estado);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return await _context.Estados.ToListAsync();
        }

        private bool EstadoExists(int id)
        {
            return (_context.Estados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
