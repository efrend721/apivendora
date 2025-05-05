using apivendora.Data;
using apivendora.Models;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services
{
    public class ConsultaService
    {
        private readonly AppDbContext _context;

        public ConsultaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Consulta>> GetAllAsync()
        {
            return await _context.Consulta.AsNoTracking().ToListAsync();
        }

        public async Task<Consulta?> GetByIdAsync(int id)
        {
            return await _context.Consulta.FindAsync(id);
        }

        public async Task AddAsync(Consulta consulta)
        {
            _context.Consulta.Add(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta == null) return false;

            _context.Consulta.Remove(consulta);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
