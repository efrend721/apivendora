using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
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
            return await _context.Mformapago.AsNoTracking().ToListAsync();
        }

        public async Task<Mformapago?> GetByIdAsync(int id)
        {
            return await _context.Mformapago.FindAsync(id);
        }

        public async Task AddAsync(Mformapago mformapago)
        {
            _context.Mformapago.Add(mformapago);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var record = await _context.Mformapago.FindAsync(id);
            if (record == null) return false;

            _context.Mformapago.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
