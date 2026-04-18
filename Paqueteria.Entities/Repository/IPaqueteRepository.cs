using Paqueteria.Domain.Entities;

namespace Paqueteria.Domain.Repository
{
    public interface IPaqueteRepository
    {
        Task<IEnumerable<Paquete>> GetAllAsync();
        Task<Paquete?> GetByIdAsync(int id);
        Task AddAsync(Paquete paquete);
        Task UpdateAsync(Paquete paquete); //para marcar como entregado
    }
}