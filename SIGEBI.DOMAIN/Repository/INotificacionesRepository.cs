using SIGEBI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Repository
{
    public interface INotificacionesRepository
    {
        Task<Notificacion> AddAsync(Notificacion notificacion); 
        Task<Notificacion> GetByIdAsync(int id);
        Task<IEnumerable<Notificacion>> GetAllAsync();
        Task UpdateAsync(Notificacion notificacion);
        Task DeleteAsync(int id);
    }
}



