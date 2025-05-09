using apivendora.Data;
using apivendora.Models.Ventas;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Ventas
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
            return await _context.Impuestos.AsNoTracking().ToListAsync();
        }

        public async Task<List<Impuesto>> GetByFacturaAsync(int idFactura)
        {
            return await _context.Impuestos
                .AsNoTracking()
                .Where(i => i.IdFactura == idFactura)
                .ToListAsync();
        }

        public async Task AddAsync(Impuesto impuesto)
        {
            _context.Impuestos.Add(impuesto);
            await _context.SaveChangesAsync();
        }
    }
}
