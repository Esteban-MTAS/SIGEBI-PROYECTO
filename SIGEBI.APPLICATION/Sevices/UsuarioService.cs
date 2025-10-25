using SIGEBI.Application.Dtos.Prestamos;
using SIGEBI.Application.Dtos.Usuarios;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public Task<IEnumerable<UsuarioDto>> GetAllAsync(int page = 1, int pageSize = 10, string? nombre = null, string? correo = null)
            => Task.FromResult<IEnumerable<UsuarioDto>>(new List<UsuarioDto>());

        public Task<UsuarioDto?> GetByIdAsync(int id)
            => Task.FromResult<UsuarioDto?>(null);

        public Task<UsuarioDto> CreateAsync(CrearUsuarioDto dto)
            => Task.FromResult(new UsuarioDto());

        public Task<bool> UpdateAsync(int id, UsuarioDto dto)
            => Task.FromResult(false);

        public Task<bool> DeleteAsync(int id)
            => Task.FromResult(false);

        public Task<IEnumerable<PrestamoDto>> GetPrestamosByUsuarioAsync(int usuarioId)
            => Task.FromResult<IEnumerable<PrestamoDto>>(new List<PrestamoDto>());
    }
}