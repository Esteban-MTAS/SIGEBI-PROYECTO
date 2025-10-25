namespace SIGEBI.Application.Dtos.Penalizaciones
{
    public class PenalizacionDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PrestamoId { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaAplicacion { get; set; }
    }

    public class ActualizarPenalizacionDto
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
    }

}