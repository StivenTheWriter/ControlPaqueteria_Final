using Paqueteria.Business.DTOs;
using Paqueteria.Domain.Entities;
using Paqueteria.Domain.Repository;

namespace Paqueteria.Business.Services
{
    public class PaqueteService : IPaqueteService
    {
        private readonly IPaqueteRepository _paqueteRepo;

        public PaqueteService(IPaqueteRepository paqueteRepo)
        {
            _paqueteRepo = paqueteRepo;
        }

        public async Task<IEnumerable<PaqueteDto>> ObtenerTodosLosPaquetes()
        {
            var paquetes = await _paqueteRepo.GetAllAsync();

            return paquetes.Select(p => new PaqueteDto
            {
                Id = p.Id,
                TrackingCode = p.TrackingCode,
                Courier = p.Courier,
                Estado = p.Estado,
                NombreResidente = p.Residente != null ? $"{p.Residente.Nombre} {p.Residente.Apellido}" : "Sin asignar"
            });
        }

        public async Task RegistrarPaquete(PaqueteDto dto, int residenteId)
        {
            var nuevoPaquete = new Paquete
            {
                TrackingCode = dto.TrackingCode,
                Courier = dto.Courier,
                ResidenteId = residenteId,
                Estado = "Pendiente"
            };
            await _paqueteRepo.AddAsync(nuevoPaquete);
        }

        public async Task EliminarPaquete(int id)
        {
            await _paqueteRepo.DeleteAsync(id);
        }

        
        public async Task MarcarComoEntregado(int id)
        {
            var paquete = await _paqueteRepo.GetByIdAsync(id); 

            if (paquete != null)
            {
                paquete.Estado = "Entregado";
                await _paqueteRepo.UpdateAsync(paquete); 
            }
        }
    }
}