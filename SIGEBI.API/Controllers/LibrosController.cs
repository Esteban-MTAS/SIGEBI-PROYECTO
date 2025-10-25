using Microsoft.AspNetCore.Mvc;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Repository;
using SIGEBI.Application.Dtos.Libros;

namespace SIGEBI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroRepository _libroRepo;

        public LibrosController(ILibroRepository libroRepo)
        {
            _libroRepo = libroRepo;
        }

        // GET: api/libros
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var libros = await _libroRepo.GetAllAsync();
            var result = libros.Select(l => new LibroDto
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Autor = l.Autor,
                ISBN = l.ISBN,
                CantidadTotal = l.CantidadTotal,
                CantidadDisponible = l.CantidadDisponible
            });
            return Ok(result);
        }

        // GET: api/libros/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var libro = await _libroRepo.GetByIdAsync(id);
            if (libro == null) return NotFound();

            var dto = new LibroDto
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Autor = libro.Autor,
                ISBN = libro.ISBN,
                CantidadTotal = libro.CantidadTotal,
                CantidadDisponible = libro.CantidadDisponible
            };
            return Ok(dto);
        }

        // POST: api/libros
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearLibroDto dto)
        {
            var libro = new Libro
            {
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                ISBN = dto.ISBN,
                FechaRegistro = DateTime.Now,
                CantidadTotal = dto.CantidadTotal,
                CantidadDisponible = dto.CantidadTotal // Inicializa igual al total
            };

            await _libroRepo.AddAsync(libro);

            var result = new LibroDto
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Autor = libro.Autor,
                ISBN = libro.ISBN,
                CantidadTotal = libro.CantidadTotal,
                CantidadDisponible = libro.CantidadDisponible
            };

            return CreatedAtAction(nameof(GetById), new { id = libro.Id }, result);
        }

        // PUT: api/libros/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LibroDto dto)
        {
            var libro = await _libroRepo.GetByIdAsync(id);
            if (libro == null) return NotFound();

            libro.Titulo = dto.Titulo;
            libro.Autor = dto.Autor;
            libro.ISBN = dto.ISBN;
            libro.CantidadTotal = dto.CantidadTotal;
            libro.CantidadDisponible = dto.CantidadDisponible;

            await _libroRepo.UpdateAsync(libro);

            return NoContent();
        }

        // DELETE: api/libros/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _libroRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}