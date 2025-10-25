using SIGEBI.Application.Dtos.Notificaciones;

namespace SIGEBI.Application.Interfaces
{
    public interface INotificacionService
    {
        Task<IEnumerable<NotificacionDto>> GetAllAsync(int page = 1, int pageSize = 10);
        Task<NotificacionDto?> GetByIdAsync(int id);
        Task<NotificacionDto> CreateAsync(CrearNotificacionDto dto);

        // Métodos que faltaban
        Task<bool> SendToUserAsync(string mensaje);
        Task<bool> SendToRoleAsync(string mensaje);
        Task<bool> SendToAllAsync(string mensaje);
    }
}

