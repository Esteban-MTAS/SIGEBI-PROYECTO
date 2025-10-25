using SIGEBI.Application.Dtos.Penalizaciones;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Application.Services
{
    public class PenalizacionService : IPenalizacionService
    {
        public Task<IEnumerable<PenalizacionDto>> GetAllAsync(int page = 1, int pageSize = 10)
            => Task.FromResult<IEnumerable<PenalizacionDto>>(new List<PenalizacionDto>());

        public Task<PenalizacionDto?> GetByIdAsync(int id)
            => Task.FromResult<PenalizacionDto?>(null);

        public Task<PenalizacionDto> CreateAsync(CrearPenalizacionDto dto)
            => Task.FromResult(new PenalizacionDto());

        public Task<bool> LevantarAsync(int id)
            => Task.FromResult(false);

        public Task<bool> RenewAsync(int id)
            => Task.FromResult(false);

        public Task<bool> DeleteAsync(int id)
            => Task.FromResult(false);
    }
}


