namespace apivendora.Repositories.Productos
{
    using apivendora.Models.Productos;

    public interface ILaboratorioRepository
    {
        Task<List<Laboratorio>> GetAllAsync();
        Task<Laboratorio?> GetByIdAsync(int cdgoLaboratorio);
        Task AddAsync(Laboratorio laboratorio);
        Task<bool> DeleteAsync(int cdgoLaboratorio);
        Task<bool> ExistsAsync(int cdgoLaboratorio);
    }
}
