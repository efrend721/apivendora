using apivendora.Data;
using apivendora.Models.Productos;
using Microsoft.EntityFrameworkCore;

namespace apivendora.Repositories.Productos
{
    public class LaboratorioRepository : ILaboratorioRepository
    {
        private readonly AppDbContext _context;

        public LaboratorioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Laboratorio>> GetAllAsync()
        {
            return await _context.Laboratorios
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Laboratorio?> GetByIdAsync(int cdgoLaboratorio)
        {
            return await _context.Laboratorios
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.CdgoLaboratorio == cdgoLaboratorio);
        }

        public async Task AddAsync(Laboratorio laboratorio)
        {
            _context.Laboratorios.Add(laboratorio);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int cdgoLaboratorio)
        {
            var lab = await _context.Laboratorios.FindAsync(cdgoLaboratorio);
            if (lab == null)
                return false;

            _context.Laboratorios.Remove(lab);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int cdgoLaboratorio)
        {
            return await _context.Laboratorios.AnyAsync(l => l.CdgoLaboratorio == cdgoLaboratorio);
        }
    }
}
