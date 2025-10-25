using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Dtos.Reportes;
using SIGEBI.Application.Dtos.Reportes.SIGEBI.Application.Dtos.Reportes;
using SIGEBI.Domain.Entities;
using SIGEBI.Persistence.Context;

namespace SIGEBI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesController : ControllerBase
    {
        private readonly SIGEBIDbContext _context;

        public ReportesController(SIGEBIDbContext context)
        {
            _context = context;
        }

        // GET: api/reportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReporteDto>>> GetAll()
        {
            var reportes = await _context.Reportes
                .Select(r => new ReporteDto
                {
                    Id = r.Id,
                    Tipo = r.Tipo,
                    FechaGeneracion = r.FechaGeneracion,
                    Datos = r.Datos,
                    GeneradoPor = r.GeneradoPor
                })
                .ToListAsync();

            return Ok(reportes);
        }

        // GET: api/reportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReporteDto>> GetById(int id)
        {
            var r = await _context.Reportes.FindAsync(id);

            if (r == null)
                return NotFound();

            return new ReporteDto
            {
                Id = r.Id,
                Tipo = r.Tipo,
                FechaGeneracion = r.FechaGeneracion,
                Datos = r.Datos,
                GeneradoPor = r.GeneradoPor
            };
        }

        // POST: api/reportes
        [HttpPost]
        public async Task<ActionResult<ReporteDto>> Create(CrearReporteDto dto)
        {
            var reporte = new Reporte
            {
                Tipo = dto.Tipo,
                Datos = dto.Datos,
                GeneradoPor = dto.GeneradoPor,
                FechaGeneracion = DateTime.Now
            };

            _context.Reportes.Add(reporte);
            await _context.SaveChangesAsync();

            var result = new ReporteDto
            {
                Id = reporte.Id,
                Tipo = reporte.Tipo,
                FechaGeneracion = reporte.FechaGeneracion,
                Datos = reporte.Datos,
                GeneradoPor = reporte.GeneradoPor
            };

            return CreatedAtAction(nameof(GetById), new { id = reporte.Id }, result);
        }

        // PUT: api/reportes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarReporteDto dto)
        {
            var reporte = await _context.Reportes.FindAsync(id);

            if (reporte == null)
                return NotFound();

            reporte.Tipo = dto.Tipo;
            reporte.Datos = dto.Datos;
            reporte.FechaActualizacion = DateTime.Now;
            reporte.ActualizadoPor = "Sistema";

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/reportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var reporte = await _context.Reportes.FindAsync(id);

            if (reporte == null)
                return NotFound();

            _context.Reportes.Remove(reporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}