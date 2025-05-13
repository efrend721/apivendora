namespace apivendora.Repositories.Productos
{
    using apivendora.Models.Productos;

    public interface IBarrasRepository
    {
        Task<List<Barras>> GetAllAsync();
        Task<Barras?> GetByIdAsync(string cdgoBarra);
        Task AddAsync(Barras barra);
        Task<bool> DeleteAsync(string cdgoBarra);
        Task<List<Barras>> GetByProductoAsync(int cdgoProducto);
        Task<bool> DeleteByProductoAsync(int cdgoProducto);
    }
}
