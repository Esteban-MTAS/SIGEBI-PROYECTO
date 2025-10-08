using SIGEBI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Repository
{
    public interface IPrestamoRepository
    {
        Task<Prestamo> GetByIdAsync(int id);
        Task<IEnumerable<Prestamo>> GetAllAsync();
        Task AddAsync(Prestamo prestamo);
        Task UpdateAsync(Prestamo prestamo);
        Task DeleteAsync(int id);
    }
}