namespace SIGEBI.Application.Dtos.Usuarios
{ 
public class CrearUsuarioDto
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Rol { get; set; }
    public string Estado { get; set; } = "Activo";
}

}
