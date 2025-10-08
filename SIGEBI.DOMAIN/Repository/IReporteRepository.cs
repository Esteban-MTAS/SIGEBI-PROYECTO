using SIGEBI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Repository
{
    public interface IReporteRepository
    {
        Task<Reporte> GetByIdAsync(int id);
        Task<IEnumerable<Reporte>> GetAllAsync();
        Task AddAsync(Reporte reporte);
        Task UpdateAsync(Reporte reporte);
        Task DeleteAsync(int id);
    }
}