using SIGEBI.Application.Dtos.Notificaciones;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Application.Services
{
    public class NotificacionService : INotificacionService
    {
        public Task<IEnumerable<NotificacionDto>> GetAllAsync(int page = 1, int pageSize = 10)
            => Task.FromResult<IEnumerable<NotificacionDto>>(new List<NotificacionDto>());

        public Task<NotificacionDto?> GetByIdAsync(int id)
            => Task.FromResult<NotificacionDto?>(null);

        public Task<NotificacionDto> CreateAsync(CrearNotificacionDto dto)
            => Task.FromResult(new NotificacionDto());

        public Task<bool> SendToUserAsync(string mensaje)
            => Task.FromResult(true);

        public Task<bool> SendToRoleAsync(string mensaje)
            => Task.FromResult(true);

        public Task<bool> SendToAllAsync(string mensaje)
            => Task.FromResult(true);
    }
}
