using apivendora.Data;
using apivendora.Models.Ventas;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Services.Ventas
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
            return await _context.Consultas.AsNoTracking().ToListAsync();
        }

        public async Task<Consulta?> GetByIdAsync(int id)
        {
            return await _context.Consultas.FindAsync(id);
        }

        public async Task AddAsync(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null) return false;

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
