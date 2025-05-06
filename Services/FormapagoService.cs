using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
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
            return await _context.Formapago.AsNoTracking().ToListAsync();
        }

        public async Task<List<Formapago>> GetByFacturaAsync(int idFactura)
        {
            return await _context.Formapago
                .AsNoTracking()
                .Where(fp => fp.IdFactura == idFactura)
                .ToListAsync();
        }

        public async Task AddAsync(Formapago formapago)
        {
            _context.Formapago.Add(formapago);
            await _context.SaveChangesAsync();
        }
    }
}
