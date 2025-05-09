using apivendora.Models.Productos;
using apivendora.Repositories.Productos;

namespace apivendora.Services.Productos
{
    public class ProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public Task<List<Producto>> GetAllAsync()
        {
            return _productoRepository.GetAllAsync();
        }

        public Task<Producto?> GetByIdAsync(int id)
        {
            return _productoRepository.GetByIdAsync(id);
        }

        public Task AddAsync(Producto producto)
        {
            return _productoRepository.AddAsync(producto);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _productoRepository.DeleteAsync(id);
        }

        public Task<bool> ExistsAsync(int id)
        {
            return _productoRepository.ExistsAsync(id);
        }
    }
}
