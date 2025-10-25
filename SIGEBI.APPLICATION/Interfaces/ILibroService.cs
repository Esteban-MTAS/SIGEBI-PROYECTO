using SIGEBI.Application.Dtos.Libros;

namespace SIGEBI.Application.Interfaces
{
    public interface ILibroService
    {
        Task<IEnumerable<LibroDto>> GetAllAsync(int page = 1, int pageSize = 10, string? autor = null, string? titulo = null);
        Task<LibroDto?> GetByIdAsync(int id);
        Task<LibroDto> CreateAsync(CrearLibroDto dto);
        Task<bool> UpdateAsync(int id, LibroDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

