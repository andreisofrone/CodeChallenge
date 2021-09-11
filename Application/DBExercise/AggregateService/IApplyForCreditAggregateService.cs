using Application.AggregateServices;
using Application.Common.Repositories.Contracts;
using AutoMapper;

namespace Application.DBExercise.AggregateService
{
    public interface IApplyForCreditAggregateService
        :IAgregateService
    {
        ITotalFutureDebtRepository TotalFutureDebtRepository { get; set; }

        IAppliedAmountRepository AppliedAmountRepository { get; set; }

        IUnitOfWork UnitOfWork { get; set; }

        IMapper Mapper { get; set; }
    }
}
