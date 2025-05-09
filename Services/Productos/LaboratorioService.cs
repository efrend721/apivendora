using apivendora.Models.Productos;
using apivendora.Repositories.Productos;

namespace apivendora.Services.Productos
{
    public class LaboratorioService
    {
        private readonly ILaboratorioRepository _laboratorioRepository;

        public LaboratorioService(ILaboratorioRepository laboratorioRepository)
        {
            _laboratorioRepository = laboratorioRepository;
        }

        public Task<List<Laboratorio>> GetAllAsync()
        {
            return _laboratorioRepository.GetAllAsync();
        }

        public Task<Laboratorio?> GetByIdAsync(int cdgoLaboratorio)
        {
            return _laboratorioRepository.GetByIdAsync(cdgoLaboratorio);
        }

        public Task AddAsync(Laboratorio laboratorio)
        {
            return _laboratorioRepository.AddAsync(laboratorio);
        }

        public Task<bool> DeleteAsync(int cdgoLaboratorio)
        {
            return _laboratorioRepository.DeleteAsync(cdgoLaboratorio);
        }

        public Task<bool> ExistsAsync(int cdgoLaboratorio)
        {
            return _laboratorioRepository.ExistsAsync(cdgoLaboratorio);
        }
    }
}
