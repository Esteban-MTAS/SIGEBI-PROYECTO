﻿namespace SIGEBI.Application.Dtos.Libros
{
    public class LibroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public bool Disponible { get; set; }
    }
}

