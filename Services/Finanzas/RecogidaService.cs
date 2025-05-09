using apivendora.Data;
using apivendora.Models.Finanzas;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Finanzas
{
    public class RecogidaService
    {
        private readonly AppDbContext _context;

        public RecogidaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Recogida>> GetAllAsync()
        {
            return await _context.Recogidas.AsNoTracking().ToListAsync();
        }

        public async Task<Recogida?> GetByIdAsync(int id)
        {
            return await _context.Recogidas.FindAsync(id);
        }

        public async Task AddAsync(Recogida recogida)
        {
            _context.Recogidas.Add(recogida);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var registro = await _context.Recogidas.FindAsync(id);
            if (registro == null) return false;

            _context.Recogidas.Remove(registro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
