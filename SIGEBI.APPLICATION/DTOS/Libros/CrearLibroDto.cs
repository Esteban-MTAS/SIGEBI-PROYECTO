namespace SIGEBI.Application.Dtos.Libros
{
    public class CrearLibroDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int CantidadTotal { get; set; }
        public int CantidadDisponible { get; set; } 
    }
}