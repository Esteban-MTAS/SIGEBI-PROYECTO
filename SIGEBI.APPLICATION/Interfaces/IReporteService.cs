using SIGEBI.Application.Dtos.Reportes;

namespace SIGEBI.Application.Interfaces
{
    public interface IReporteService
    {
        
        Task<ReporteDto> GenerarPrestamosActivosAsync();

        
        Task<ReporteDto> GenerarPenalizacionesAsync();

        Task<ReporteDto> GenerarLibrosMasPrestadosAsync(DateTime fechaInicio, DateTime fechaFin);
       
        Task<ReporteDto> GenerarUsuariosConMasPrestamosAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}