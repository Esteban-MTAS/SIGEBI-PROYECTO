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
                Disponible = l.Disponible
            });
            return Ok(result);
        }

     
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
                Disponible = libro.Disponible
            };
            return Ok(dto);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearLibroDto dto)
        {
            var libro = new Libro
            {
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                ISBN = dto.ISBN,
                Disponible = true,
                FechaRegistro = DateTime.Now
            };

            await _libroRepo.AddAsync(libro);

            return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LibroDto dto)
        {
            var libro = await _libroRepo.GetByIdAsync(id);
            if (libro == null) return NotFound();

            libro.Titulo = dto.Titulo;
            libro.Autor = dto.Autor;
            libro.ISBN = dto.ISBN;
            libro.Disponible = dto.Disponible;

            await _libroRepo.UpdateAsync(libro);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _libroRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}