using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
{
    public class TinventarioService
    {
        private readonly AppDbContext _context;

        public TinventarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tinventario>> GetAllAsync()
        {
            return await _context.Tinventario.AsNoTracking().ToListAsync();
        }

        public async Task<Tinventario?> GetByIdAsync(int id)
        {
            return await _context.Tinventario.FindAsync(id);
        }

        public async Task AddAsync(Tinventario item)
        {
            _context.Tinventario.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Tinventario.FindAsync(id);
            if (item == null) return false;

            _context.Tinventario.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
