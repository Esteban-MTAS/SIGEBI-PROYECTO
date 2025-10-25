using SIGEBI.Application.Dtos.Libros;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Application.Services
{
    public class LibroService : ILibroService
    {
        public Task<IEnumerable<LibroDto>> GetAllAsync(int page = 1, int pageSize = 10, string? autor = null, string? titulo = null)
            => Task.FromResult<IEnumerable<LibroDto>>(new List<LibroDto>());

        public Task<LibroDto?> GetByIdAsync(int id)
            => Task.FromResult<LibroDto?>(null);

        public Task<LibroDto> CreateAsync(CrearLibroDto dto)
            => Task.FromResult(new LibroDto());

        public Task<bool> UpdateAsync(int id, LibroDto dto)
            => Task.FromResult(false);

        public Task<bool> DeleteAsync(int id)
            => Task.FromResult(false);
    }
}

