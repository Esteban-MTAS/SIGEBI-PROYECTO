namespace SIGEBI.Application.Dtos.Penalizaciones
{
    public class CrearPenalizacionDto
    {
        public int UsuarioId { get; set; }
        public int PrestamoId { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
    }


}