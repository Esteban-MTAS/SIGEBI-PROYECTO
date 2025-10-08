using SIGEBI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Repository
{
    public interface INotificacionRepository
    {
        Task<Notificacion> GetByIdAsync(int id);
        Task<IEnumerable<Notificacion>> GetAllAsync();
        Task AddAsync(Notificacion notificacion);
        Task UpdateAsync(Notificacion notificacion);
        Task DeleteAsync(int id);
    }
}