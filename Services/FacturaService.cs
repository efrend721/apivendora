using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
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
            return await _context.Factura.AsNoTracking().ToListAsync();
        }

        public async Task<Factura?> GetByIdAsync(int idFactura)
        {
            return await _context.Factura.FindAsync(idFactura);
        }

        public async Task AddAsync(Factura factura)
        {
            _context.Factura.Add(factura);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int idFactura)
        {
            var factura = await _context.Factura.FindAsync(idFactura);
            if (factura == null) return false;

            _context.Factura.Remove(factura);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
