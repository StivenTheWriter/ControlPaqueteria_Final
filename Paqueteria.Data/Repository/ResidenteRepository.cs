using Paqueteria.Domain.Entities;
using Paqueteria.Domain.Repository;
using Paqueteria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Paqueteria.Infrastructure.Repositories // Asegúrate que termine en .Repositories
{
    public class ResidenteRepository : IResidenteRepository
    {
        private readonly ApplicationDbContext _context;

        public ResidenteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Residente>> GetAllAsync() => await _context.Residentes.ToListAsync();

        public async Task<Residente?> GetByIdAsync(int id) => await _context.Residentes.FindAsync(id);

        public async Task AddAsync(Residente residente)
        {
            await _context.Residentes.AddAsync(residente);
            await _context.SaveChangesAsync();
        }
    }
}