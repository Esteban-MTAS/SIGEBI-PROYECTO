using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Persistence.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly SIGEBIDbContext _context;

        public ReporteRepository(SIGEBIDbContext context)
        {
            _context = context;
        }

        public async Task<Reporte> GetByIdAsync(int id)
            => await _context.Reportes
                             .Include(r => r.Usuario)
                             .FirstOrDefaultAsync(r => r.Id == id);

        public async Task<IEnumerable<Reporte>> GetAllAsync()
            => await _context.Reportes
                             .Include(r => r.Usuario)
                             .ToListAsync();

        public async Task AddAsync(Reporte reporte)
        {
            await _context.Reportes.AddAsync(reporte);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reporte reporte)
        {
            _context.Reportes.Update(reporte);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reporte = await _context.Reportes.FindAsync(id);
            if (reporte != null)
            {
                _context.Reportes.Remove(reporte);
                await _context.SaveChangesAsync();
            }
        }
    }
}

