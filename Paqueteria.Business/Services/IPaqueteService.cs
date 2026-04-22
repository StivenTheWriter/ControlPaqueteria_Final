using Paqueteria.Business.DTOs;

namespace Paqueteria.Business.Services
{
    public interface IPaqueteService
    {
        Task<IEnumerable<PaqueteDto>> ObtenerTodosLosPaquetes();
        Task RegistrarPaquete(PaqueteDto paqueteDto, int residenteId);
        Task EliminarPaquete(int id);
    }
}