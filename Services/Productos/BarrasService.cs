using apivendora.Models.Productos;
using apivendora.Data;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Productos
{
    public class BarrasService
    {
        private readonly AppDbContext _context;

        public BarrasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Barras>> GetAllAsync()
        {
            return await _context.Barras.AsNoTracking().ToListAsync();
        }

        public async Task<Barras?> GetByIdAsync(string cdgoBarra)
        {
            return await _context.Barras
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.CdgoBarra == cdgoBarra);
        }

        public async Task AddAsync(Barras barra)
        {
            _context.Barras.Add(barra);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(string cdgoBarra)
        {
            var barra = await _context.Barras.FindAsync(cdgoBarra);
            if (barra == null) return false;

            _context.Barras.Remove(barra);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
