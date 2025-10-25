using SIGEBI.Application.Dtos.Prestamos;

namespace SIGEBI.Application.Interfaces
{
    public interface IPrestamoService
    {
        Task<IEnumerable<PrestamoDto>> GetAllAsync(int page = 1, int pageSize = 10);
        Task<PrestamoDto?> GetByIdAsync(int id);
        Task<PrestamoDto> CreateAsync(CrearPrestamoDto dto);
        Task<bool> DevolverAsync(int id);

     
        Task<IEnumerable<PrestamoDto>> GetByUsuarioAsync(int usuarioId);
        Task<IEnumerable<PrestamoDto>> GetActivosAsync();
        Task<bool> DeleteAsync(int id);
    }
}