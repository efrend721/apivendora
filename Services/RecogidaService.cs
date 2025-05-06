using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
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
            return await _context.Recogida.AsNoTracking().ToListAsync();
        }

        public async Task<Recogida?> GetByIdAsync(int id)
        {
            return await _context.Recogida.FindAsync(id);
        }

        public async Task AddAsync(Recogida recogida)
        {
            _context.Recogida.Add(recogida);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var registro = await _context.Recogida.FindAsync(id);
            if (registro == null) return false;

            _context.Recogida.Remove(registro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
