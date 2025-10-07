using Lab8_RodrigoApaza.Infrastructure.Repositories.Interfaces;

namespace Lab8_RodrigoApaza.Infrastructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<int> SaveAsync();
    }
}