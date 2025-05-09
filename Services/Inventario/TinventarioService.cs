using apivendora.Data;
using apivendora.Models.Inventario;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Inventario
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
            return await _context.Tinventarios.AsNoTracking().ToListAsync();
        }

        public async Task<Tinventario?> GetByIdAsync(int id)
        {
            return await _context.Tinventarios.FindAsync(id);
        }

        public async Task AddAsync(Tinventario item)
        {
            _context.Tinventarios.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Tinventarios.FindAsync(id);
            if (item == null) return false;

            _context.Tinventarios.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
