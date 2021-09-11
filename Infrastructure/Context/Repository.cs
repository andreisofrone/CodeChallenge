using Application.Common.Repositories.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public abstract class Repository<T>
       : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IQueryable<T>> GetAll()
        {
            return await Task.Run(() => _context.Set<T>().AsQueryable());
        }

        public virtual async Task<T> FindByIdAsync(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
