using Application.Common.Extensions;
using Application.Common.Repositories.Contracts;
using Application.DBExercise.Dtos;
using Application.DBExercise.Messages.Commands;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DBExercise.Handlers
{
    public class ApplyForCreditCommandHandler
            : IRequestHandler<ApplyForCreditCommand, SolutionDto>
    {
        ITotalFutureDebtRepository TotalFutureDebtRepository { get; set; }

        IAppliedAmountRepository AppliedAmountRepository { get; set; }


        public ApplyForCreditCommandHandler(ITotalFutureDebtRepository totalFutureDebtRepository, IAppliedAmountRepository appliedAmountRepository)
        {
            TotalFutureDebtRepository = totalFutureDebtRepository ?? throw new ArgumentNullException(nameof(totalFutureDebtRepository));
            AppliedAmountRepository = appliedAmountRepository ?? throw new ArgumentNullException(nameof(appliedAmountRepository));
        }

        public async Task<SolutionDto> Handle(ApplyForCreditCommand request, CancellationToken cancellationToken)
        {
            var totalFutureDebt = request.CreditAmount + request.CurrentPreExistingCreditAmount;
            var totalFutureDebtRange = (await TotalFutureDebtRepository.GetAll())
                                             .FirstOrDefault(am => totalFutureDebt >= am.LowerBound && totalFutureDebt < am.UpperBound);
            var appliedAmountRange = (await AppliedAmountRepository
                                             .GetAll())
                                             .FirstOrDefault(am => request.CreditAmount >= am.LowerBound && request.CreditAmount < am.UpperBound);

            return new SolutionDto()
            {
                Decision = appliedAmountRange.Decision.ToYesNoString(),
                InterestRate = totalFutureDebtRange.InterestRate
            };
        }
    }
}
