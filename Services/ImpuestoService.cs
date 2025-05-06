using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
{
    public class ImpuestoService
    {
        private readonly AppDbContext _context;

        public ImpuestoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Impuesto>> GetAllAsync()
        {
            return await _context.Impuesto.AsNoTracking().ToListAsync();
        }

        public async Task<List<Impuesto>> GetByFacturaAsync(int idFactura)
        {
            return await _context.Impuesto
                .AsNoTracking()
                .Where(i => i.IdFactura == idFactura)
                .ToListAsync();
        }

        public async Task AddAsync(Impuesto impuesto)
        {
            _context.Impuesto.Add(impuesto);
            await _context.SaveChangesAsync();
        }
    }
}
