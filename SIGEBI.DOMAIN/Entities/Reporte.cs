namespace SIGEBI.DOMAIN.Entities
{
    internal class Reporte
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Autor { get; set; }
    }
}
