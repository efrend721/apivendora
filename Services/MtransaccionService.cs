using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
{
    public class MtransaccionService
    {
        private readonly AppDbContext _context;

        public MtransaccionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Mtransaccion>> GetAllAsync()
        {
            return await _context.Mtransaccion.AsNoTracking().ToListAsync();
        }

        public async Task<Mtransaccion?> GetByIdAsync(string codigo)
        {
            return await _context.Mtransaccion.FindAsync(codigo);
        }

        public async Task AddAsync(Mtransaccion transaccion)
        {
            _context.Mtransaccion.Add(transaccion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(string codigo)
        {
            var transaccion = await _context.Mtransaccion.FindAsync(codigo);
            if (transaccion == null) return false;

            _context.Mtransaccion.Remove(transaccion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
