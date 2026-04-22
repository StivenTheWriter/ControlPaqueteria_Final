using Microsoft.EntityFrameworkCore;
using Paqueteria.Domain.Entities;
using Paqueteria.Domain.Repository;
using Paqueteria.Infrastructure.Context;

namespace Paqueteria.Infrastructure.Repositories
{
    public class PaqueteRepository : IPaqueteRepository
    {
        private readonly ApplicationDbContext _context;

        public PaqueteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paquete>> GetAllAsync()
        {
            
            return await _context.Paquetes.Include(p => p.Residente).ToListAsync();
        }

        public async Task<Paquete?> GetByIdAsync(int id)
        {
            return await _context.Paquetes.Include(p => p.Residente)
                                         .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Paquete paquete)
        {
            await _context.Paquetes.AddAsync(paquete);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paquete paquete)
        {
            _context.Paquetes.Update(paquete);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete != null)
            {
                _context.Paquetes.Remove(paquete);
                await _context.SaveChangesAsync();
            }
        }
    }
}