using SIGEBI.Application.Dtos.Prestamos;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Application.Services
{
    public class PrestamoService : IPrestamoService
    {
        public Task<IEnumerable<PrestamoDto>> GetAllAsync(int page = 1, int pageSize = 10)
            => Task.FromResult<IEnumerable<PrestamoDto>>(new List<PrestamoDto>());

        public Task<PrestamoDto?> GetByIdAsync(int id)
            => Task.FromResult<PrestamoDto?>(null);

        public Task<PrestamoDto> CreateAsync(CrearPrestamoDto dto)
            => Task.FromResult(new PrestamoDto());

        public Task<bool> DevolverAsync(int id)
            => Task.FromResult(false);

        public Task<IEnumerable<PrestamoDto>> GetByUsuarioAsync(int usuarioId)
            => Task.FromResult<IEnumerable<PrestamoDto>>(new List<PrestamoDto>());

        public Task<IEnumerable<PrestamoDto>> GetActivosAsync()
            => Task.FromResult<IEnumerable<PrestamoDto>>(new List<PrestamoDto>());

        public Task<bool> DeleteAsync(int id)
            => Task.FromResult(false);
    }
}