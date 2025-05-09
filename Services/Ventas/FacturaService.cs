using apivendora.Data;
using apivendora.Models.Ventas;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Ventas
{
    public class FacturaService
    {
        private readonly AppDbContext _context;

        public FacturaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Factura>> GetAllAsync()
        {
            return await _context.Facturas.AsNoTracking().ToListAsync();
        }

        public async Task<Factura?> GetByIdAsync(int idFactura)
        {
            return await _context.Facturas.FindAsync(idFactura);
        }

        public async Task AddAsync(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int idFactura)
        {
            var factura = await _context.Facturas.FindAsync(idFactura);
            if (factura == null) return false;

            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
