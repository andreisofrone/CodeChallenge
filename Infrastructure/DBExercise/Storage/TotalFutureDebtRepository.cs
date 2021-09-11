using Application.Common.Models;
using Application.Common.Repositories;
using Application.Common.Repositories.Contracts;
using Infrastructure.Context;

namespace Infrastructure.DBExercise.Storage
{
    public class TotalFutureDebtRepository
           : Repository<TotalFutureDebt>, ITotalFutureDebtRepository
    {
        public TotalFutureDebtRepository(AppDbContext context)
             : base(context)
        {
        }
    }
}

