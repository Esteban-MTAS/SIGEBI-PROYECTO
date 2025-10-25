using SIGEBI.Application.Dtos.Prestamos;
using SIGEBI.Application.Dtos.Usuarios;

namespace SIGEBI.Application.Interfaces
{
    public interface IUsuarioService
    {
      
        Task<IEnumerable<UsuarioDto>> GetAllAsync(int page = 1, int pageSize = 10, string? nombre = null, string? correo = null);
       
        Task<UsuarioDto?> GetByIdAsync(int id);
        
        Task<UsuarioDto> CreateAsync(CrearUsuarioDto dto);

        Task<bool> UpdateAsync(int id, UsuarioDto dto);

     
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<PrestamoDto>> GetPrestamosByUsuarioAsync(int usuarioId);
    }
}