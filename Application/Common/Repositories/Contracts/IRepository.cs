using System.Linq;
using System.Threading.Tasks;

namespace Application.Common.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAll();

        Task<T> FindByIdAsync(long id);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
