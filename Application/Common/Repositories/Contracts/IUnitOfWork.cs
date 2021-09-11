using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

        Task CompleteAsync(CancellationToken token);
    }
}
