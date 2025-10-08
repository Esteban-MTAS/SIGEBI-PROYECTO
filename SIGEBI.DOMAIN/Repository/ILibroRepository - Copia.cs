using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Repository
{
    public interface ILibroRepository
    {
        Task<Libro> GetByIdAsync(int id);
        Task<IEnumerable<Libro>> GetAllAsync();
        Task AddAsync(Libro libro);
        Task UpdateAsync(Libro libro);
        Task DeleteAsync(int id);
    }
}

