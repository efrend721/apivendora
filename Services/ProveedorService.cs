using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
{
    public class ProveedorService
    {
        private readonly AppDbContext _context;

        public ProveedorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedor.AsNoTracking().ToListAsync();
        }

        public async Task<Proveedor?> GetByIdAsync(string id)
        {
            return await _context.Proveedor.FindAsync(id);
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            _context.Proveedor.Add(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor == null) return false;

            _context.Proveedor.Remove(proveedor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
