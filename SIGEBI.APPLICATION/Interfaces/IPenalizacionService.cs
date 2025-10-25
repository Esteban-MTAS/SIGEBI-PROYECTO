using SIGEBI.Application.Dtos.Penalizaciones;

namespace SIGEBI.Application.Interfaces
{
    public interface IPenalizacionService
    {
        Task<IEnumerable<PenalizacionDto>> GetAllAsync(int page = 1, int pageSize = 10);
        Task<PenalizacionDto?> GetByIdAsync(int id);
        Task<PenalizacionDto> CreateAsync(CrearPenalizacionDto dto);
        Task<bool> LevantarAsync(int id);

     
        Task<bool> RenewAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}