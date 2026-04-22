using Paqueteria.Domain.Entities;
using Paqueteria.Domain.Repository;
using Paqueteria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Paqueteria.Infrastructure.Repositories 
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

        public async Task UpdateAsync(Residente residente)
        {
            _context.Residentes.Update(residente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var residente = await GetByIdAsync(id);
            if (residente != null)
            {
                _context.Residentes.Remove(residente);
                await _context.SaveChangesAsync();
            }
        }

    }
}