namespace SIGEBI.Domain.Base
{
    public abstract class AuditEntity
    {
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public DateTime? FechaActualizacion { get; set; }
        public string? CreadoPor { get; set; }
        public string? ActualizadoPor { get; set; }
    }
}

    