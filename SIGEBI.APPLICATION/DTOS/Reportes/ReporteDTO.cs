namespace SIGEBI.Application.Dtos.Reportes
{
    public class ReporteDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public string Datos { get; set; }
        public int GeneradoPor { get; set; }
    }
    namespace SIGEBI.Application.Dtos.Reportes
    {
        public class ActualizarReporteDto
        {
            public int Id { get; set; }
            public string Tipo { get; set; }
            public string Datos { get; set; }
        }
    }
}