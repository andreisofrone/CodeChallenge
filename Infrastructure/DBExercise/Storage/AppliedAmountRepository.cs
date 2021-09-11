using Application.Common.Models;
using Application.Common.Repositories.Contracts;
using Infrastructure.Context;

namespace Infrastructure.DBExercise.Storage
{
    public class AppliedAmountRepository
          : Repository<AppliedAmount>, IAppliedAmountRepository
    {
        public AppliedAmountRepository(AppDbContext context)
             : base(context)
        {
        }
    }
}
