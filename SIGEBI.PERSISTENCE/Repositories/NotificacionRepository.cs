using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class NotificacionRepository : INotificacionesRepository
    {
        private readonly SIGEBIDbContext _context;

        public NotificacionRepository(SIGEBIDbContext context)
        {
            _context = context;
        }

        public async Task<Notificacion> AddAsync(Notificacion notificacion)
        {
            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();
            return notificacion;
        }

        public async Task<Notificacion?> GetByIdAsync(int id)
        {
            return await _context.Notificaciones.FindAsync(id);
        }

        public async Task<IEnumerable<Notificacion>> GetAllAsync()
        {
            return await Task.FromResult(_context.Notificaciones.ToList());
        }

        public async Task UpdateAsync(Notificacion notificacion)
        {
            _context.Notificaciones.Update(notificacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            if (notificacion != null)
            {
                _context.Notificaciones.Remove(notificacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}