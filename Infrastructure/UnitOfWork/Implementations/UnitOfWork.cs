using Lab8_RodrigoApaza.Infrastructure.Data;
using Lab8_RodrigoApaza.Infrastructure.Repositories.Implementations;
using Lab8_RodrigoApaza.Infrastructure.Repositories.Interfaces;
using Lab8_RodrigoApaza.Infrastructure.UnitOfWork.Interfaces;

namespace Lab8_RodrigoApaza.Infrastructure.UnitOfWork.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LinqDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(LinqDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
                return (IGenericRepository<T>)_repositories[typeof(T)];

            var repoInstance = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repoInstance);
            return repoInstance;
        }

        public async Task<int> SaveAsync() =>
            await _context.SaveChangesAsync();

        public void Dispose() =>
            _context.Dispose();
    }
}