using apivendora.Data;
using apivendora.Models.Ventas;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Ventas
{
    public class MformapagoService
    {
        private readonly AppDbContext _context;

        public MformapagoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Mformapago>> GetAllAsync()
        {
            return await _context.Mformapagos.AsNoTracking().ToListAsync();
        }

        public async Task<Mformapago?> GetByIdAsync(int id)
        {
            return await _context.Mformapagos.FindAsync(id);
        }

        public async Task AddAsync(Mformapago mformapago)
        {
            _context.Mformapagos.Add(mformapago);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var record = await _context.Mformapagos.FindAsync(id);
            if (record == null) return false;

            _context.Mformapagos.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
