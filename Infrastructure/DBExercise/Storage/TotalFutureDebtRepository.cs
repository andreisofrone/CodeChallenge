using Application.Common.Models;
using Application.Common.Repositories.Contracts;
using Infrastructure.Context;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

