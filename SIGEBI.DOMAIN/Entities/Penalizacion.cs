namespace SIGEBI.DOMAIN.Entities
{
    internal class Penalizacion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Razon { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activa { get; set; }
    }
}
