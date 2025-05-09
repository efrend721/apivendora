using apivendora.Models.Productos;
using apivendora.Repositories.Productos;

namespace apivendora.Services.Productos
{
    public class BarrasService
    {
        private readonly IBarrasRepository _barrasRepository;

        public BarrasService(IBarrasRepository barrasRepository)
        {
            _barrasRepository = barrasRepository;
        }

        public Task<List<Barras>> GetAllAsync()
        {
            return _barrasRepository.GetAllAsync();
        }

        public Task<Barras?> GetByIdAsync(string cdgoBarra)
        {
            return _barrasRepository.GetByIdAsync(cdgoBarra);
        }

        public Task<List<Barras>> GetByProductoAsync(int cdgoProducto)
        {
            return _barrasRepository.GetByProductoAsync(cdgoProducto);
        }

        public Task AddAsync(Barras barra)
        {
            return _barrasRepository.AddAsync(barra);
        }

        public Task<bool> DeleteAsync(string cdgoBarra)
        {
            return _barrasRepository.DeleteAsync(cdgoBarra);
        }
    }
}
