using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Persistence.Repositories
{
    public class PenalizacionRepository : IPenalizacionRepository
    {
        private readonly SIGEBIDbContext _context;

        public PenalizacionRepository(SIGEBIDbContext context)
        {
            _context = context;
        }

        public async Task<Penalizacion> GetByIdAsync(int id)
            => await _context.Penalizaciones
                             .Include(p => p.Usuario)
                             .Include(p => p.Prestamo)
                             .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Penalizacion>> GetAllAsync()
            => await _context.Penalizaciones
                             .Include(p => p.Usuario)
                             .Include(p => p.Prestamo)
                             .ToListAsync();

        public async Task AddAsync(Penalizacion penalizacion)
        {
            await _context.Penalizaciones.AddAsync(penalizacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Penalizacion penalizacion)
        {
            _context.Penalizaciones.Update(penalizacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var penalizacion = await _context.Penalizaciones.FindAsync(id);
            if (penalizacion != null)
            {
                _context.Penalizaciones.Remove(penalizacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}

