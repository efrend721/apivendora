using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
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
            return await _context.Laboratorio.AsNoTracking().ToListAsync();
        }

        public async Task<Laboratorio?> GetByIdAsync(int id)
        {
            return await _context.Laboratorio.FindAsync(id);
        }

        public async Task AddAsync(Laboratorio laboratorio)
        {
            _context.Laboratorio.Add(laboratorio);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var laboratorio = await _context.Laboratorio.FindAsync(id);
            if (laboratorio == null) return false;

            _context.Laboratorio.Remove(laboratorio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
