using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Dtos.Usuarios;
using SIGEBI.Domain.Entities;
using SIGEBI.Persistence.Context;

namespace SIGEBI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly SIGEBIDbContext _context;

        public UsuariosController(SIGEBIDbContext context)
        {
            _context = context;
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll()
        {
            var usuarios = await _context.Usuarios
                .Select(u => new UsuarioDto
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Rol = u.Rol,
                    Estado = u.Estado
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            var u = await _context.Usuarios.FindAsync(id);

            if (u == null)
                return NotFound();

            return new UsuarioDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Email = u.Email,
                Rol = u.Rol,
                Estado = u.Estado
            };
        }

        // POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Create(CrearUsuarioDto dto)
        {
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                Rol = dto.Rol,
                Estado = string.IsNullOrEmpty(dto.Estado) ? "Activo" : dto.Estado
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var result = new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Rol = usuario.Rol,
                Estado = usuario.Estado
            };

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, result);
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarUsuarioDto dto)
        {
            if (id != dto.Id)
                return BadRequest("El ID de la URL no coincide con el del objeto.");

            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound();

            usuario.Nombre = dto.Nombre;
            usuario.Email = dto.Email;
            usuario.Rol = dto.Rol;
            usuario.Estado = dto.Estado;
            usuario.FechaActualizacion = DateTime.Now;
            usuario.ActualizadoPor = "Sistema";

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}