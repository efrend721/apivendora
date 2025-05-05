using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
{
    public class DefacturaService
    {
        private readonly AppDbContext _context;

        public DefacturaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Defactura>> GetAllAsync()
        {
            return await _context.Defactura.AsNoTracking().ToListAsync();
        }

        public async Task<List<Defactura>> GetByFacturaAsync(int idFactura)
        {
            return await _context.Defactura
                .AsNoTracking()
                .Where(d => d.IdFactura == idFactura)
                .ToListAsync();
        }

        public async Task AddAsync(Defactura defactura)
        {
            _context.Defactura.Add(defactura);
            await _context.SaveChangesAsync();
        }
    }
}
