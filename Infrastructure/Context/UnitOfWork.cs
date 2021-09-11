using Application.Common.Repositories.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class UnitOfWork
        : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task CompleteAsync(CancellationToken token)
        {
            await context.SaveChangesAsync(token);
        }
    }
}
