using apivendora.Data;
using apivendora.Models.Inventario;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Inventario
{
    public class SaldosService
    {
        private readonly AppDbContext _context;

        public SaldosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Saldos>> GetAllAsync()
        {
            return await _context.Saldos.AsNoTracking().ToListAsync();
        }

        public async Task<Saldos?> GetByIdAsync(int cdgoProducto)
        {
            return await _context.Saldos.FindAsync(cdgoProducto);
        }

        public async Task AddAsync(Saldos saldo)
        {
            _context.Saldos.Add(saldo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int cdgoProducto)
        {
            var saldo = await _context.Saldos.FindAsync(cdgoProducto);
            if (saldo == null) return false;

            _context.Saldos.Remove(saldo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
