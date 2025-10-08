using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Persistence.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly SIGEBIDbContext _context;

        public PrestamoRepository(SIGEBIDbContext context)
        {
            _context = context;
        }

        public async Task<Prestamo> GetByIdAsync(int id)
            => await _context.Prestamos
                             .Include(p => p.Libro)
                             .Include(p => p.Usuario)
                             .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Prestamo>> GetAllAsync()
            => await _context.Prestamos
                             .Include(p => p.Libro)
                             .Include(p => p.Usuario)
                             .ToListAsync();

        public async Task AddAsync(Prestamo prestamo)
        {
            await _context.Prestamos.AddAsync(prestamo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
                await _context.SaveChangesAsync();
            }
        }
    }
}

