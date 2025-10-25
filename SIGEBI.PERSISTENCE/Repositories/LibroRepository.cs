using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Persistence.Repositories   
{
    public class LibroRepository : ILibroRepository
    {
        private readonly SIGEBIDbContext _context;

        public LibroRepository(SIGEBIDbContext context)
        {
            _context = context;
        }

        public async Task<Libro> GetByIdAsync(int id)
            => await _context.Libros.FindAsync(id);

        public async Task<IEnumerable<Libro>> GetAllAsync()
            => await _context.Libros.ToListAsync();

        public async Task AddAsync(Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Libro libro)
        {
            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
