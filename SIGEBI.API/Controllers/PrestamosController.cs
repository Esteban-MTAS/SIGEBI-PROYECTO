using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Dtos.Prestamos;
using SIGEBI.Application.Dtos.Prestamos.SIGEBI.Application.Dtos.Prestamos;
using SIGEBI.Domain.Entities;
using SIGEBI.Persistence.Context;

namespace SIGEBI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly SIGEBIDbContext _context;

        public PrestamosController(SIGEBIDbContext context)
        {
            _context = context;
        }

        // GET: api/prestamos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrestamoDto>>> GetAll()
        {
            var prestamos = await _context.Prestamos
                .Select(p => new PrestamoDto
                {
                    Id = p.Id,
                    UsuarioId = p.UsuarioId,
                    LibroId = p.LibroId,
                    RegistradoPor = p.RegistradoPor,
                    FechaPrestamo = p.FechaPrestamo,
                    FechaDevolucion = p.FechaDevolucion,
                    Estado = p.Estado
                })
                .ToListAsync();

            return Ok(prestamos);
        }

        // GET: api/prestamos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrestamoDto>> GetById(int id)
        {
            var p = await _context.Prestamos.FindAsync(id);

            if (p == null)
                return NotFound();

            return new PrestamoDto
            {
                Id = p.Id,
                UsuarioId = p.UsuarioId,
                LibroId = p.LibroId,
                RegistradoPor = p.RegistradoPor,
                FechaPrestamo = p.FechaPrestamo,
                FechaDevolucion = p.FechaDevolucion,
                Estado = p.Estado
            };
        }

        // POST: api/prestamos
        [HttpPost]
        public async Task<ActionResult<PrestamoDto>> Create(CrearPrestamoDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.UsuarioId);
            var libro = await _context.Libros.FindAsync(dto.LibroId);

            if (usuario == null || libro == null)
                return BadRequest("Usuario o libro no encontrado.");

            if (usuario.Estado != "Activo")
                return BadRequest("El usuario está suspendido o tiene multa.");

            if (libro.CantidadDisponible <= 0)
                return BadRequest("No hay ejemplares disponibles.");

            var prestamosActivos = await _context.Prestamos
                .Where(p => p.UsuarioId == dto.UsuarioId && p.Estado == "Activo")
                .ToListAsync();

            if (prestamosActivos.Count >= 3)
                return BadRequest("El usuario ha alcanzado el límite de préstamos activos.");

            var prestamo = new Prestamo
            {
                UsuarioId = dto.UsuarioId,
                LibroId = dto.LibroId,
                RegistradoPor = dto.RegistradoPor,
                FechaPrestamo = DateTime.Now,
                FechaDevolucion = dto.FechaDevolucion,
                Estado = "Activo"
            };

            libro.CantidadDisponible--;

            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();

            var result = new PrestamoDto
            {
                Id = prestamo.Id,
                UsuarioId = prestamo.UsuarioId,
                LibroId = prestamo.LibroId,
                RegistradoPor = prestamo.RegistradoPor,
                FechaPrestamo = prestamo.FechaPrestamo,
                FechaDevolucion = prestamo.FechaDevolucion,
                Estado = prestamo.Estado
            };

            return CreatedAtAction(nameof(GetById), new { id = prestamo.Id }, result);
        }

        // PUT: api/prestamos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarPrestamoDto dto)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
                return NotFound();

            var libro = await _context.Libros.FindAsync(prestamo.LibroId);
            var usuario = await _context.Usuarios.FindAsync(prestamo.UsuarioId);

            prestamo.FechaDevolucion = dto.FechaDevolucion;
            prestamo.Estado = dto.Estado;
            prestamo.FechaActualizacion = DateTime.Now;
            prestamo.ActualizadoPor = "Sistema";

            if (dto.Estado == "Devuelto")   
            {
                libro.CantidadDisponible++;

                if (dto.FechaDevolucion > prestamo.FechaDevolucion)
                {
                    usuario.Estado = "ConMulta";
                  
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/prestamos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);

            if (prestamo == null)
                return NotFound();

            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}