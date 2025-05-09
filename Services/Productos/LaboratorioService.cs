using apivendora.Data;
using apivendora.Models.Productos;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Productos
{
    public class LaboratorioService
    {
        private readonly AppDbContext _context;

        public LaboratorioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Laboratorio>> GetAllAsync()
        {
            return await _context.Laboratorios.AsNoTracking().ToListAsync();
        }

        public async Task<Laboratorio?> GetByIdAsync(int id)
        {
            return await _context.Laboratorios.FindAsync(id);
        }

        public async Task AddAsync(Laboratorio laboratorio)
        {
            _context.Laboratorios.Add(laboratorio);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var laboratorio = await _context.Laboratorios.FindAsync(id);
            if (laboratorio == null) return false;

            _context.Laboratorios.Remove(laboratorio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
