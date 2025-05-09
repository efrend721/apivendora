using apivendora.Data;
using apivendora.Models.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Usuarios
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
            return await _context.Cajeras.AsNoTracking().ToListAsync();
        }

        public async Task<Cajera?> GetByIdAsync(int id)
        {
            return await _context.Cajeras.FindAsync(id);
        }
        public async Task<List<Cajera>> GetByCajaAsync(short caja)
        {
            return await _context.Cajeras
                .Where(c => c.Caja == caja)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task AddAsync(Cajera cajera)
        {
            _context.Cajeras.Add(cajera);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cajera = await _context.Cajeras.FindAsync(id);
            if (cajera == null) return false;

            _context.Cajeras.Remove(cajera);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
