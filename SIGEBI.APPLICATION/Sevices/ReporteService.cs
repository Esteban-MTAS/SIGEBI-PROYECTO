using SIGEBI.Application.Dtos.Reportes;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Application.Services
{
    public class ReporteService : IReporteService
    {
        public Task<ReporteDto> GenerarPrestamosActivosAsync()
            => Task.FromResult(new ReporteDto());

        public Task<ReporteDto> GenerarPenalizacionesAsync()
            => Task.FromResult(new ReporteDto());

        public Task<ReporteDto> GenerarLibrosMasPrestadosAsync(DateTime fechaInicio, DateTime fechaFin)
            => Task.FromResult(new ReporteDto());

        public Task<ReporteDto> GenerarUsuariosConMasPrestamosAsync(DateTime fechaInicio, DateTime fechaFin)
            => Task.FromResult(new ReporteDto());
    }
}