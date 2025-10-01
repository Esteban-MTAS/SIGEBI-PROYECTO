namespace SIGEBI.DOMAIN.Entities
{
    public class Libro
    {                           
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Editorial { get; set; }
        public int NumeroPaginas { get; set; }
        public string Genero { get; set; }
        public string Idioma { get; set; }
        public string Descripcion { get; set; }
        public bool Disponible { get; set; }
    }
}
