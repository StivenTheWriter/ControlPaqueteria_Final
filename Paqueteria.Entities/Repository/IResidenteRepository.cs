using Paqueteria.Domain.Entities;

namespace Paqueteria.Domain.Repository
{
    public interface IResidenteRepository
    {
        Task<IEnumerable<Residente>> GetAllAsync();
        Task<Residente?> GetByIdAsync(int id);
        Task AddAsync(Residente residente);
    }
}