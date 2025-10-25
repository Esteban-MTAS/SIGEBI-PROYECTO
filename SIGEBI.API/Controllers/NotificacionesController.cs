using Microsoft.AspNetCore.Mvc;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Repository;
using SIGEBI.Application.Dtos.Notificaciones;

namespace SIGEBI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionesRepository _notiRepo;

        public NotificacionesController(INotificacionesRepository notiRepo)
        {
            _notiRepo = notiRepo;
        }

        // GET: api/notificaciones
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notificaciones = await _notiRepo.GetAllAsync();
            var result = notificaciones.Select(n => new NotificacionDto
            {
                Id = n.Id,
                UsuarioId = n.UsuarioId,
                Mensaje = n.Mensaje,
                FechaEnvio = n.FechaEnvio,
                Leido = n.Leido
            });
            return Ok(result);
        }

        // GET: api/notificaciones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var noti = await _notiRepo.GetByIdAsync(id);
            if (noti == null) return NotFound();

            var dto = new NotificacionDto
            {
                Id = noti.Id,
                UsuarioId = noti.UsuarioId,
                Mensaje = noti.Mensaje,
                FechaEnvio = noti.FechaEnvio,
                Leido = noti.Leido
            };
            return Ok(dto);
        }

        // POST: api/notificaciones
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearNotificacionDto dto)
        {
            var noti = new Notificacion
            {
                UsuarioId = dto.UsuarioId,
                Mensaje = dto.Mensaje,
                FechaEnvio = DateTime.Now,
                Leido = false
            };

            await _notiRepo.AddAsync(noti);
            return CreatedAtAction(nameof(GetById), new { id = noti.Id }, noti);
        }

        // PUT: api/notificaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NotificacionDto dto)
        {
            var noti = await _notiRepo.GetByIdAsync(id);
            if (noti == null) return NotFound();

            noti.Mensaje = dto.Mensaje;
            noti.Leido = dto.Leido;
            noti.FechaEnvio = dto.FechaEnvio;
            noti.UsuarioId = dto.UsuarioId;

            await _notiRepo.UpdateAsync(noti);
            return NoContent();
        }

        // DELETE: api/notificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _notiRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}