using apivendora.Data;
using apivendora.Models.Ventas;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Ventas
{
    public class FormapagoService
    {
        private readonly AppDbContext _context;

        public FormapagoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Formapago>> GetAllAsync()
        {
            return await _context.Formapagos.AsNoTracking().ToListAsync();
        }

        public async Task<List<Formapago>> GetByFacturaAsync(int idFactura)
        {
            return await _context.Formapagos
                .AsNoTracking()
                .Where(fp => fp.IdFactura == idFactura)
                .ToListAsync();
        }

        public async Task AddAsync(Formapago formapago)
        {
            _context.Formapagos.Add(formapago);
            await _context.SaveChangesAsync();
        }
    }
}
