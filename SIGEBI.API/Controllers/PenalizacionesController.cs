using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Dtos.Penalizaciones;
using SIGEBI.Domain.Entities;
using SIGEBI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace SIGEBI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PenalizacionesController : ControllerBase
    {
        private readonly SIGEBIDbContext _context;

        public PenalizacionesController(SIGEBIDbContext context)
        {
            _context = context;
        }

        // GET: api/penalizaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PenalizacionDto>>> GetAll()
        {
            var penalizaciones = await _context.Penalizaciones
                .Select(p => new PenalizacionDto
                {
                    Id = p.Id,
                    UsuarioId = p.UsuarioId,
                    PrestamoId = p.PrestamoId,
                    Monto = p.Monto,
                    Motivo = p.Motivo,
                    Estado = p.Estado,
                    FechaAplicacion = p.FechaAplicacion
                })
                .ToListAsync();

            return Ok(penalizaciones);
        }

        // GET: api/penalizaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PenalizacionDto>> GetById(int id)
        {
            var p = await _context.Penalizaciones.FindAsync(id);

            if (p == null)
                return NotFound();

            return new PenalizacionDto
            {
                Id = p.Id,
                UsuarioId = p.UsuarioId,
                PrestamoId = p.PrestamoId,
                Monto = p.Monto,
                Motivo = p.Motivo,
                Estado = p.Estado,
                FechaAplicacion = p.FechaAplicacion
            };
        }

        // POST: api/penalizaciones
        [HttpPost]
        public async Task<ActionResult<PenalizacionDto>> Create(CrearPenalizacionDto dto)
        {
            var penalizacion = new Penalizacion
            {
                UsuarioId = dto.UsuarioId,
                PrestamoId = dto.PrestamoId,
                Monto = dto.Monto,
                Motivo = dto.Motivo,
                Estado = "Pendiente",
                FechaAplicacion = DateTime.Now
            };

            _context.Penalizaciones.Add(penalizacion);
            await _context.SaveChangesAsync();

            var result = new PenalizacionDto
            {
                Id = penalizacion.Id,
                UsuarioId = penalizacion.UsuarioId,
                PrestamoId = penalizacion.PrestamoId,
                Monto = penalizacion.Monto,
                Motivo = penalizacion.Motivo,
                Estado = penalizacion.Estado,
                FechaAplicacion = penalizacion.FechaAplicacion
            };

            return CreatedAtAction(nameof(GetById), new { id = penalizacion.Id }, result);
        }

        // PUT: api/penalizaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarPenalizacionDto dto)
        {
            var penalizacion = await _context.Penalizaciones.FindAsync(id);

            if (penalizacion == null)
                return NotFound();

            penalizacion.Monto = dto.Monto;
            penalizacion.Motivo = dto.Motivo;
            penalizacion.Estado = dto.Estado;
            penalizacion.FechaActualizacion = DateTime.Now;
            penalizacion.ActualizadoPor = "Sistema";

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/penalizaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var penalizacion = await _context.Penalizaciones.FindAsync(id);

            if (penalizacion == null)
                return NotFound();

            _context.Penalizaciones.Remove(penalizacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}