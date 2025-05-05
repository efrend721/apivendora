using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
{
    public class CajeraService
    {
        private readonly AppDbContext _context;

        public CajeraService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cajera>> GetAllAsync()
        {
            return await _context.Cajera.AsNoTracking().ToListAsync();
        }

        public async Task<Cajera?> GetByIdAsync(int id)
        {
            return await _context.Cajera.FindAsync(id);
        }
        public async Task<List<Cajera>> GetByCajaAsync(short caja)
        {
            return await _context.Cajera
                .Where(c => c.Caja == caja)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task AddAsync(Cajera cajera)
        {
            _context.Cajera.Add(cajera);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cajera = await _context.Cajera.FindAsync(id);
            if (cajera == null) return false;

            _context.Cajera.Remove(cajera);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
