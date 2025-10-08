using SIGEBI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Repository
{
    public interface IPenalizacionRepository
    {
        Task<Penalizacion> GetByIdAsync(int id);
        Task<IEnumerable<Penalizacion>> GetAllAsync();
        Task AddAsync(Penalizacion penalizacion);
        Task UpdateAsync(Penalizacion penalizacion);
        Task DeleteAsync(int id);
    }
}