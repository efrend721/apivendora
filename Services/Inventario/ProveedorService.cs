using apivendora.Data;
using apivendora.Models.Inventario;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Inventario
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
            return await _context.Proveedores.AsNoTracking().ToListAsync();
        }

        public async Task<Proveedor?> GetByIdAsync(string id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null) return false;

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
