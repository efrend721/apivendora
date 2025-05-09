using apivendora.Data;
using apivendora.Models.Inventario;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Inventario
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
            return await _context.Mtransacciones.AsNoTracking().ToListAsync();
        }

        public async Task<Mtransaccion?> GetByIdAsync(string codigo)
        {
            return await _context.Mtransacciones.FindAsync(codigo);
        }

        public async Task AddAsync(Mtransaccion transaccion)
        {
            _context.Mtransacciones.Add(transaccion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(string codigo)
        {
            var transaccion = await _context.Mtransacciones.FindAsync(codigo);
            if (transaccion == null) return false;

            _context.Mtransacciones.Remove(transaccion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
