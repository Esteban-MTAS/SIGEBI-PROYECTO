namespace SIGEBI.Application.Dtos.Notificaciones
{
    public class NotificacionDto
    {
        public int Id { get; set; }                 
        public int UsuarioId { get; set; }         
        public string Mensaje { get; set; } = "";   
        public DateTime FechaEnvio { get; set; }   
        public bool Leido { get; set; }             
    }
}